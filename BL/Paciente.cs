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
                                    string direccion, string lugarNac, string estado)
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
