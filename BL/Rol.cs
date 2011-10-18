using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess; //para el ADO Entity
using System.Data;// ^^
using System.Data.Objects;// ^^ y haber agregado la referencia a System.Data.Entity -->

namespace BL
{
    public class Rol
    {
        #region variables
        DataAccess.teletonEntities entidad;        
        #endregion

        #region gets y sets        
        #endregion

        #region constructores        
        public Rol()
        {
            try
            {
                entidad = new teletonEntities();
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString() + " --Rol.cs / Rol()");
            }
        }
        #endregion

        public List<long> getRolesID()
        {
            try
            {
                var allRolsID = from r in entidad.roles
                              select r.id;

                return allRolsID.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + " --Rol.cs / getRolesID()");
            }
        }

        public List<string> getRolesDescripcion()
        {
            try
            {
                var allRolsDesc = from r in entidad.roles
                                  select r.descripcion;
                return allRolsDesc.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + " --Rol.cs / getRoelsDescripcion()");
            }
        }

        public long getRolID(string descripcion)
        {
            try
            {
                var rolID = from r in entidad.roles
                            where r.descripcion == descripcion
                            select r.id;
                
                return rolID.First();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + " --Rol.cs / getRolID()");
            }
        }

        public string getRolDescripcion(long identity)
        {
            try
            {
                var rolDesc = from r in entidad.roles
                              where r.id == identity
                              select r.descripcion;
                return rolDesc.First();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + " --Rol.cs / getRolDescripcion()");
            }
        }

        public List<string> getRolPermisos(long identity)
        {
            try
            {
                List<string> pers = new List<string>();

                var rolsPers = from r in entidad.roles
                               where r.id == identity
                               select r;

                DataAccess.role rl = rolsPers.First();                

                foreach (DataAccess.permiso p in rl.permisos)
                {
                    pers.Add(p.id);
                }
                
                return pers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + " --Rol.cs / getRolPermisos()");
            }
        }

        public List<string> getRolPermisos(string description)
        {
            try
            {
                List<string> pers = new List<string>();

                var rolsPers = from r in entidad.roles
                               where r.descripcion == description
                               select r;

                DataAccess.role rl = rolsPers.First();

                foreach (DataAccess.permiso p in rl.permisos)
                {
                    pers.Add(p.id);
                }

                return pers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + " --Rol.cs / getRolPermisos()");
            }
        }        

        public List<long> getRolesUsuario(string username)
        {
            try
            {
                List<long> rols = new List<long>();

                var userQuery = from u in entidad.usuarios
                                where u.username == username
                                select u;
                DataAccess.usuario usrtmp = userQuery.First();

                foreach (role rl in usrtmp.roles)
                {
                    rols.Add(rl.id);
                }

                return rols;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + " --Rol.cs / getRolesUsuario()");
            }
        }
    }
}
