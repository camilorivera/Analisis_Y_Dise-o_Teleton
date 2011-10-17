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
    public class AdministradordeSistema
    {

        #region variables
        private Security security;
        #endregion

        #region gets y sets

        #endregion

        #region constructores
        public AdministradordeSistema()
        {
            try
            {
                security = new Security();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + " --AdministradordeSistema.cs / AdministradordeSistema()");
            }
        }
        #endregion

        public void crearPermiso(string name, string description)
        {
            try
            {
                security.crear_permiso(name, description);

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString() + " --AdministradordeSistema.cs / crearPermiso()");
            }
        }

        public void crearRol(string description, List<string> licences, long centro)
        {
            try
            {
                security.crear_rol(description, licences, centro);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString() + " --AdministradordeSistema.cs / crearRol()");
            }
        }

        public void eliminarPermiso(string identity)
        {
            try
            {
                security.eliminar_permiso(identity);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString() + " --AdministradordeSistema.cs / eliminarPermiso()");
            }
        }

        public void eliminarRol(long identity)
        {
            try
            {
                security.eliminar_rol(identity);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString() + " --AdministradordeSistema.cs / eliminarRol()");
            }
        }

        public void editarRol(long identity, string description, List<string> grants, List<string> revokes, long nuevoCentro)
        {
            try
            {
                security.editar_rol(identity, description, grants, revokes, nuevoCentro);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString() + " --AdministradordeSistema.cs / editarRol()");
            }
        }


        






    }
}

