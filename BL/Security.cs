using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess; //para el ADO Entity
using System.Data;// ^^
using System.Data.Objects;// ^^
using System.Data.Objects.DataClasses;// ^^ y haber agregado la referencia a System.Data.Entity --> 

namespace BL
{
    public class Security
    {
        #region variables
        DataAccess.teletonEntities entidad;
        private long idEmp;
        #endregion

        #region gets y sets
        public int GetPositionId(string nombrecargo)
        {
            var query = from pos in entidad.cargos
                        where nombrecargo == pos.cargo1
                        select pos.id;
            int posId = Convert.ToInt32(query.First());

            return posId;
        }


        public int GetEmpId(string nombre)
        {
            var idemp_query = from p in entidad.empleados
                              where nombre == p.nombres
                              select p.id;
            int emp_id = Convert.ToInt32(idemp_query.First());

            return emp_id;

        }
        #endregion

        #region constructores
        public Security()
        {
            try
            {
                entidad = new teletonEntities();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + " --Security.cs / Security()");
            }
        }
        #endregion

        #region permisos

        public void crear_permiso(string name, string description)
        {
            try
            {
                DataAccess.permiso permisoNuevo = new permiso();//creacion de permiso
                permisoNuevo.id = name;
                permisoNuevo.descripcion = description;

                entidad.permisos.AddObject(permisoNuevo);
                entidad.SaveChanges();//commit
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString() + " --Security.cs / crear_permiso()");
            }
        }        

        public void eliminar_permiso(string permisoCod)
        {
            try
            {
                var permisoQuery = from per in entidad.permisos
                                   where per.id == permisoCod
                                   select per;

                DataAccess.permiso permisoTMP = permisoQuery.First();
                entidad.DeleteObject(permisoTMP);
                entidad.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString() + " --Security.cs / eliminar_permiso()");
            }
        }

        #endregion

        #region roles

        public void crear_rol(string descripcion, List<string> licences, long centro)
        {
            try
            {
                DataAccess.role rolNuevo = new role();//creacion de rol
                rolNuevo.descripcion = descripcion;
                rolNuevo.centro = centro;
                entidad.roles.AddObject(rolNuevo);//agregar el rol nuevo al contexto
                entidad.SaveChanges();//commit1

                foreach (string permisoCod in licences)
                {
                    var permisoQuery = from per in entidad.permisos
                                       where per.id == permisoCod
                                       select per;

                    DataAccess.permiso permisoTMP = permisoQuery.First();
                    rolNuevo.permisos.Add(permisoTMP);//ya que el permisos en roles es un collection, agregamos cada permiso utilizando el id que viene en la lista
                }
                entidad.SaveChanges();//commit2 --> 2 commits por el autoincrement del rol.id!!
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString() + " --Security.cs / crear_rol()");
            }
        }                

        public void editar_rol(long identity, string description, List<string> grants, List<string> revokes, long nuevoCentro)
        {
            try
            {
                var rolQuery = from rol in entidad.roles
                               where rol.id == identity
                               select rol;

                DataAccess.role rolTMP = rolQuery.First();
                rolTMP.descripcion = description;
                rolTMP.centro = nuevoCentro;                

                foreach (string perm in grants)
                {
                    var permisoQuery = from per in entidad.permisos
                                       where per.id == perm
                                       select per;

                    rolTMP.permisos.Add(permisoQuery.First());
                }

                foreach (string perm in revokes)
                {
                    var permisoQuery = from per in entidad.permisos
                                       where per.id == perm
                                       select per;

                    rolTMP.permisos.Remove(permisoQuery.First());
                }
                entidad.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString() + " --Security.cs / editar_rol()");
            }
        }

        public void eliminar_rol(long identity)
        {
            try
            {
                var rolQuery = from rol in entidad.roles
                               where rol.id == identity
                               select rol;

                DataAccess.role rolTMP = rolQuery.First();
                entidad.DeleteObject(rolTMP);
                entidad.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString() + " --Security.cs / eliminar_rol()");
            }
        }

        #endregion

        #region login

        public bool login(string user, string password, string centroActual)
        {
            try
            {
                Login l = new Login(user, password);
                bool tmp = l.validateUser(centroActual);

                if (tmp)
                {
                    idEmp = l.getidEmp();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + "  --Security.cs / login()");
            }
        }

        public List<String> getCentros()
        {
            try
            {
                List<String> centros; 

                var allcentros = from c in entidad.centros
                                 select c.lugar;

                centros = allcentros.ToList();
                return centros;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + "  --Security.cs / getCentros()");
            }
        }

        public List<string> getCentrosPermitidos(string username)
        {
            //TODO: hacer que esta funcion devuelva los centros permitidos para editar por el username
            try
            {
                List<string> centros = new List<string>();

                /*var allcentros = from c in entidad.centros
                                 select c.lugar;

                centros = allcentros.ToList();
                return centros;*/
                
                var query = (from u in entidad.usuarios
                          where u.username == username
                          select u).First();

                

                foreach (role rol in query.roles)
                {
                    if(!centros.Contains(rol.centro1.lugar))
                        centros.Add(rol.centro1.lugar);
                }

                return centros;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + "  --Security.cs / getCentrosPermitidos()");
            }
        }

        public long getCentroId(string centro)
        {
            var QCId = from c in entidad.centros
                       where c.lugar == centro
                       select c.id;
            long CId = 0;
            foreach (long l in QCId)
                CId = l;
            return CId;

        }

        public string getCentrolugar(int centro) //devuelve nombre del centro
        {
            var QCId = from c in entidad.centros
                       where c.id == centro
                       select c.lugar;
            string CId="";
            foreach (string l in QCId)
                CId = l;
            return CId;

        }

        public string getCentrolugarNom(string centro) //devuelve nombre del centro recibe string
        {                                               //esta funcion se usa en Buscar_Nombres
            var QCId = from c in entidad.centros
                       where c.lugar.Contains(centro)
                       select c.lugar;
            string CId = "";
            foreach (string l in QCId)
                CId = l;
            return CId;

        }

        public long getidEmp()
        {
            try
            {
                return idEmp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + "  --Security.cs / getidEmp()");
            }
        }

        #endregion

        public List<string> getPermisosUsuario(string username)
        {
            try
            {
                return new Permiso().getPermisosUsuario(username);
            }catch(Exception ex)
            {
                throw new Exception(ex.ToString() + "  --Security.cs / getPermisosUsuarios()");
            }
        }

        public List<long> getRolesUsuario(string username)
        {
            try
            {
                return new Rol().getRolesUsuario(username);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + "  --Security.cs / getRolesUsuarios()");
            }
        }

        public DataTable CargarAreas()
        {
            DataTable dt_Hist = new DataTable();
            dt_Hist.Columns.Add("area1");
            //dt_Hist.Columns.Add("id");

            try
            {
                var query = from a in entidad.areas
                            orderby a.orden
                            select new { a.area1, a.id };

                foreach (var row in query)
                {
                    //dt_Hist.Rows.Add("<a href=\"~/HistoPacienteFrame.aspx?id=" + row.id.ToString() + "\" target=\"hitopaciente_frame\">" + row.area1.ToString() + "</a>");
                    dt_Hist.Rows.Add(row.id.ToString() + " " + row.area1.ToString());
                    //dt_Hist.Rows.Add(row.id.ToString());
                }
                return dt_Hist;
            }
            catch
            {
                return null;
            }
        }

        public string getNameArea(int id)//devuelve el area
        {
            
            var query = from p in entidad.areas
                        where p.id == id
                        select p.area1;


            return query.First().ToString();
           
        }
    }
}
