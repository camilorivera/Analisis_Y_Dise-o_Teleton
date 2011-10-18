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
    public class Permiso
    {
        #region variables
        DataAccess.teletonEntities entidad;        
        #endregion

        #region gets y sets        
        #endregion

        #region constructores
        public Permiso()
        {
            try
            {
                entidad = new teletonEntities();               
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString() + " --Permiso.cs / Permiso()");
            }
        }        
        #endregion

        public List<string> getPermisosID()
        {
            try
            {
                List<string> persID;

                var allpersID = from p in entidad.permisos
                              select p.id;

                persID = allpersID.ToList();
                return persID;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + " --Permiso.cs / getPermisosID()");
            }
        }

        public List<string> getPermisosDescripciones()
        {
            try
            {
                List<string> persDescripcion;

                var allPersDescripcion = from p in entidad.permisos
                                         select p.descripcion;

                persDescripcion = allPersDescripcion.ToList();
                return persDescripcion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + " --Permiso.cs / getPermisosDescripciones()");
            }
        }

        public string getPermisoID(string description)
        {
            try
            {
                var perID = from p in entidad.permisos
                            where p.descripcion == description
                            select p.id;

                return perID.First();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + " --Permiso.cs / getPermisoID()");
            }
        }

        public string getPermisoDescripcion(string identity)
        {
            try
            {
                var perDescripcion = from p in entidad.permisos
                                     where p.id == identity
                                     select p.descripcion;

                return perDescripcion.First();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + " --Permiso.cs / getPermisoDescripcion()");
            }
        }

        public List<string> getPermisosUsuario(string username)
        {
            try
            {
                List<string> pers = new List<string>();

                var usrQuery = from u in entidad.usuarios
                               where u.username == username
                               select u;

                DataAccess.usuario usrtmp = usrQuery.First();

                foreach (role rl in usrtmp.roles)
                {
                    foreach (permiso per in rl.permisos)
                    {
                        pers.Add(per.id);
                    }
                }

                return pers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + " --Permiso.cs / getPermisosUsuario()");
            }
        }
    }
}
