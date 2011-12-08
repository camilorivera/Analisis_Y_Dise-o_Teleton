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
    public class Paciente
    {
        #region variables
        private DataAccess.teletonEntities entities;
        private string _nombres;
        private string _primerApellido;
        private string _segundoApellido;
        private DateTime _fechaNac;
        private bool _sexo;
        private DateTime _fechaIngreso;
        private string _cedula;
        private string _direccion;
        private string _lugarNac;
        private string _estado;
        private int _centroActual;
        private long _expediente;
        private byte[] _foto;

        #endregion

        #region Get y Set
        public string Nombres
        {
            get { return _nombres; }
            set { _nombres = value; }
        }

        public string PrimerApellido
        {
            get { return _primerApellido; }
            set { _primerApellido = value; }
        }

        public string SegundoApellido
        {
            get { return _segundoApellido; }
            set { _segundoApellido = value; }
        }

        public DateTime FechaNac
        {
            get { return _fechaNac; }
            set { _fechaNac = value; }
        }

        public bool Sexo
        {
            get { return _sexo; }
            set { _sexo = value; }
        }

        public DateTime FechaIngreso
        {
            get { return _fechaIngreso; }
            set { _fechaIngreso = value; }
        }

        public string Cedula
        {
            get { return _cedula; }
            set { _cedula = value; }
        }

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        public string LugarNac
        {
            get { return _lugarNac; }
            set { _lugarNac = value; }
        }

        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public int CentroActual
        {
            get { return _centroActual; }
            set { _centroActual = value; }
        }

        public long Expediente
        {
            get {return _expediente;}
        }

        public byte[] Foto
        {
            get { return _foto; }
            set { _foto = value; }
        }
        #endregion

        #region Constructores
        public Paciente()
        {
            Nombres = "";
            PrimerApellido = "";
            SegundoApellido = "";
            FechaNac = DateTime.Now;
            Sexo = true;
            FechaIngreso = DateTime.Now;
            Cedula = "";
            Direccion = "";
            LugarNac = "";
            Estado = "";
            entities = new teletonEntities();
        }
        #endregion

        public void asignarDatos(int centroActual, long expediente, string nombres, string primerApellido, string segundoApellido,
                                    DateTime fechaNac, bool sexo, DateTime fechaIngreso, string cedula,
                                    string direccion, string lugarNac, string estado, byte[] foto)
        {
            CentroActual = centroActual;
            _expediente = expediente;
            Nombres = nombres;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            FechaNac = fechaNac;
            Sexo = sexo;
            FechaIngreso = fechaIngreso;
            Cedula = cedula;
            Direccion = direccion;
            LugarNac = lugarNac;
            Estado = estado;
            Foto = foto;
        }

        /// <summary>
        /// Guardar Historial
        /// </summary>
        /// <param name="dt_fecha">Fecha</param>
        /// <param name="int_Exp">Expediente</param>
        /// <param name="str_Usuario">Usuario</param>
        /// <param name="str_Histo">Texto - Historial</param>
        /// <param name="sht_Pref">Prefijo</param>
        /// <returns></returns>
        public bool guardarHistorial(DateTime dt_fecha, int int_Exp, string str_Usuario, string str_Histo, short sht_Pref)
        {
            try
            {
                DataAccess.historial da_Hist = new DataAccess.historial();
                da_Hist.fecha = dt_fecha;
                da_Hist.n_expediente = int_Exp;
                da_Hist.username = str_Usuario;
                da_Hist.texto = str_Histo;
                da_Hist.prefijo = sht_Pref;
                entities.historials.AddObject(da_Hist);
                entities.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Get nombre de paciente
        /// </summary>
        /// <param name="int_expt">N'umero de expediente</param>
        /// <returns>Nombre de Paciente</returns>
        public string[] nombrePaciente(int int_expt)
        {
            try
            {
                string[] str_Paci = new string[2];
                var query = from x in entities.pacientes
                            where x.expediente == int_expt
                            select new {x.nombres, x.primer_apellido,x.segundo_apellido,x.prefijo };
                foreach (var row in query)
                {
                    str_Paci[0] = row.nombres + " " + row.primer_apellido + " " + row.segundo_apellido;
                    str_Paci[1] = row.prefijo.ToString();
                }
                return str_Paci;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Historial del Paciente
        /// </summary>
        /// <param name="int_exp"></param>
        /// <returns></returns>
        public DataTable historial(int int_exp)
        {
            DataTable dt_Hist = new DataTable();
            dt_Hist.Columns.Add("fecha");
            dt_Hist.Columns.Add("n_expediente");
            dt_Hist.Columns.Add("username");
            dt_Hist.Columns.Add("historial");
            try
            {
                var query = from p in entities.historials
                            where p.n_expediente == int_exp
                            select new { p.fecha, p.n_expediente, p.username, p.texto };
                foreach (var row in query)
                {
                    dt_Hist.Rows.Add(row.fecha.ToString(),row.n_expediente.ToString(),row.username.ToString(),row.texto);
                }
                return dt_Hist;
            }
            catch
            {
                return null;
            }
        }

        private bool isTheInfoComplete()
        {

            return FechaIngreso != null && PrimerApellido.Length > 0 && SegundoApellido.Length > 0 && Nombres.Length > 0 && Cedula.Length > 0 && FechaNac != null;
        }

        public bool exist()
        {
            DataAccess.paciente pac = entities.pacientes.FirstOrDefault(
                        P => P.cedula == Cedula && P.centro_actual == CentroActual);
            if (pac == null)
                return false;
            else
                return true;
        }

        public bool exist(int prefijo, long expediente)
        {
            DataAccess.paciente pac = entities.pacientes.FirstOrDefault(
                        P => P.prefijo == prefijo && P.expediente == expediente);
            if (pac != null)
                return true;
            else
                return false;
        }

        public bool leerPaciente(int centroActual, long expediente)
        {
            DataAccess.paciente pac = entities.pacientes.FirstOrDefault(
                        P => P.centro_actual == centroActual && P.expediente == expediente);
            if (pac != null)
            {
                _centroActual = centroActual;
                _expediente = expediente;
                _nombres = pac.nombres;
                _primerApellido = pac.primer_apellido;
                _segundoApellido = pac.segundo_apellido;
                _fechaNac = pac.fecha_nac;
                _sexo = pac.sexo;
                _fechaIngreso = pac.fecha_ingreso;
                _cedula = pac.cedula;
                _direccion = pac.direccion;
                _lugarNac = pac.lugar_nac;
                _estado = pac.estado_civil;
                _foto = pac.foto;
                return true;
            }
            return false;
        }

        public bool editarPaciente()
        {
            try
            {
                DataAccess.paciente pac = entities.pacientes.FirstOrDefault(
                    a => a.expediente == Expediente && a.centro_actual == CentroActual);

                pac.cedula = Cedula;
                pac.direccion = Direccion;
                pac.estado_civil = Estado;
                pac.fecha_ingreso = FechaIngreso;
                pac.fecha_nac = FechaNac;

                pac.lugar_nac = LugarNac;
                pac.nombres = Nombres;
                pac.primer_apellido = PrimerApellido;
                pac.segundo_apellido = SegundoApellido;
                pac.sexo = Sexo;
                entities.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool eliminarPaciente()
        {
            try
            {
                DataAccess.paciente pac = entities.pacientes.FirstOrDefault(
                    a => a.expediente == Expediente && a.centro_actual == CentroActual);
                entities.DeleteObject(pac);
                entities.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool guardarPaciente()
        {
            if (isTheInfoComplete())
            {
                try
                {
                    DataAccess.paciente pac = new DataAccess.paciente();
                    pac.cedula = Cedula;
                    pac.direccion = Direccion;
                    pac.estado_civil = Estado;
                    pac.fecha_ingreso = FechaIngreso;
                    pac.fecha_nac = FechaNac;

                    pac.lugar_nac = LugarNac;
                    pac.nombres = Nombres;
                    pac.primer_apellido = PrimerApellido;
                    pac.segundo_apellido = SegundoApellido;
                    pac.sexo = Sexo;

                    pac.centro_actual = CentroActual;
                    pac.prefijo = CentroActual;
                    pac.expediente = Expediente;

                    pac.tipo_doc_alterno = "N/A";
                    pac.numero_doc_alt = "N/A";
                    pac.foto = Foto;

                    entities.pacientes.AddObject(pac); //se guarda en la memoria
                    entities.SaveChanges(); //se guarda en la DB
                    return true;

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString() + "Pacientes.cs / guardarPaciente()");
                }
            }
            return false;
        }
    }
}
