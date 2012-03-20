using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;


namespace BL
{
    public class Usuarios
    {

        #region Variables
        DataAccess.teletonEntities entities;
        #endregion

        #region Constructor
        public Usuarios() {
            entities = new teletonEntities();
        }

        #endregion

        #region Funciones


        public List<String> RetrieveEmployees() //Retorna Una Lista de Empleados
        {
            var query = from p in entities.empleados select p;
            List<string> Emp = new List<string>();
            foreach (empleado name in query)
                Emp.Add(name.nombres);
            return Emp;
        }

        public List<String> RetrieveRol() //Retorna Una Lista de Roles
        {
            var query = from r in entities.roles select r;
            List<string> Roles = new List<string>();
            foreach (role name in query)
                Roles.Add(name.descripcion);
            return Roles;
        }

        public string RetrieveUserName(string nombreempleado) 
        {
            try 
            {
                var query = from e in entities.empleados
                                where e.nombres == nombreempleado
                                select e.id;
                long id = query.First();

                var query1 = from u in entities.usuarios
                             where u.empleado == id
                             select u.username;

                return query1.First().ToString();

            }
            catch(Exception err)
            {
                throw new Exception(err.ToString());
            }
            
        }

        public string RetrieveUserName2(long idEmpleado)
        {
            try
            {

                var query1 = from u in entities.usuarios
                             where u.empleado == idEmpleado
                             select u.username;

                return query1.First().ToString();

            }
            catch (Exception err)
            {
                throw new Exception(err.ToString());
            }

        }

        public List<string> RetrieveEmpleadosid() //Retorna IDs de empleado que esta no en tab usuario
        {
            try
            {
                List<string> usrs = new List<string>();


                var users = from p in entities.empleados
                            where 0 == (from z in entities.usuarios
                                        where p.id == z.empleado
                                        select z.empleado).Count()
                            select p.nombres;


                foreach (var u in users)
                    usrs.Add(u);
                //usrs.Add(u.username);
                return usrs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + " --Usuario.cs / RetrieveEmpleadosid()");
            }
        }

        public List<String>RetrieveRolUser(string nombreempleado){
            try
            {
                List <string> RolesUsuario=new List<string>();
                string username = RetrieveUserName(nombreempleado);

                //DataAccess.usuario usr=new DataAccess.usuario;
                var query = (from e in entities.usuarios
                            where e.username == username
                            select e.roles).First();

                foreach (role r in query) {
                    RolesUsuario.Add(r.descripcion);
                    
                }

                return RolesUsuario;


            }
            catch (Exception err) { 
                throw new Exception (err.ToString());
            }
        }

        public List<String>RetrieveNewRolList(string nombreempleado){

            List<string> NuevaListaRolesSistema = new List<string>();
            List<string>RolesdelSistema = RetrieveRol();
            List<string> RolesdelUsuario = RetrieveRolUser(nombreempleado);

            string username = RetrieveUserName(nombreempleado);

            for (int x = 0; x < RolesdelSistema.Count(); x++)
            {
                bool found = false;
                for (int y = 0; y < RolesdelUsuario.Count();y++)
                {
                    if (RolesdelSistema[x] == RolesdelUsuario[y]){
                        found = true; 
                        break;
                    }                    
                }
                if (found == false)
                {
                    NuevaListaRolesSistema.Add(RolesdelSistema[x]);
                }

            }

            return NuevaListaRolesSistema;
        }

        public void GuardarUsuario(string nombreusuario,string contrasenia,string empleado,List<string>Roles){

          
             DataAccess.usuario USUARIOS = new DataAccess.usuario();

            try
            {
                var query = from i in entities.empleados
                            where empleado == i.nombres
                            select i.id;

                int IdEmp = Convert.ToInt32(query.First());


                     foreach (string username in Roles)
                     {

                        var userRol = (from us in entities.roles
                                     where us.descripcion == username
                                     select us).First();
                        USUARIOS.roles.Add(userRol);
                     } 
                   
                    USUARIOS.username = nombreusuario;
                    USUARIOS.password = contrasenia;
                    USUARIOS.empleado = IdEmp;

                    entities.usuarios.AddObject(USUARIOS);
                    entities.SaveChanges();

              
            }
            catch (Exception e) {

                throw new Exception(e.ToString());
            }


        }

        public void EditarUsuario(string nombrempleado, List<string> RolUsuario) {
            try
            {
                string usrname = RetrieveUserName(nombrempleado);

                var usr = (from u in entities.usuarios
                          where u.username == usrname
                          select u).First();

                usr.roles.Clear();

                foreach (string rol in RolUsuario)
                {
                    var roltmp = (from r in entities.roles
                                where r.descripcion == rol
                                select r).First();
                    usr.roles.Add(roltmp);
                }

                entities.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString() + " --Usuario.cs / EditarUsuario()");
            }
        }

        public List<string> RetrieveUserNames()
        {
            try
            {
                List<string> usrs = new List<string>();

                var users = from u in entities.usuarios
                            select u;

                foreach (usuario u in users)
                    usrs.Add(u.username);

                return usrs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + " --Usuario.cs / RetrieveUserNames()");
            }
        }

        public void EliminarUsuario(string username)
        {
            try
            {
                var user = (from u in entities.usuarios
                           where u.username == username
                           select u).First();

                entities.DeleteObject(user);
                entities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + " --Usuario.cs / EliminarUsuario()");
            }
        }

        public long retriveEmpId(string userName)
        {

            try
            {
                var query = from x in entities.usuarios
                            where x.username == userName
                            select x.empleado;

                long id = query.First();

                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + "--Empleados.cs /obtenerNombresDoctores");
            }
        }


        #endregion

    }

}
