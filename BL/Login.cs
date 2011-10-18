using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace BL
{
    public class Login
    {
        #region Variables
        DataAccess.teletonEntities entidad;
        private string userName;
        private string password;
        private long idEmp;        
        #endregion

        public Login(string userName, string password)
        {
            try
            {
                this.userName = userName;
                this.password = password;
                entidad = new DataAccess.teletonEntities();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString() + "  --Login.cs / Login()");
            }
        }

        public bool validateUser(string centroActual)
        {
            try
            {
                var usuarioQuery = from user in entidad.usuarios
                                   where user.username == userName && user.password == password
                                   select user;

                usuario[] usr = usuarioQuery.ToArray();
                   
                if (usr.Length != 0)
                {
                    bool centroEncontrado = false;
                    
                    foreach (role r in usr[0].roles)
                    {
                        centro ctr = r.centro1;

                        if (centroActual == ctr.lugar)
                        {
                            centroEncontrado = true;
                            break;
                        }
                    }

                    if (centroEncontrado)
                    {

                        this.idEmp = usr[0].empleado;
                        return true;
                    }
                    else
                        return false;
                } else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + "  --Login.cs / validateUser()");
            }
        }

        public long getidEmp()
        {
            try
            {       
                return this.idEmp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + "  --Login.cs / getidEmp()");
            }
        }        
    }
}
