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

        /*Modificado por Eliazar*/
        private string _telefono;
        private string _movil;
        private long _idEscolaridad;
        private long _idProfesion;
        private string _lugarTrabajo;
        private string _nombreMadre;
        private string _nombrePadre;
        private string _estructuraFamiliar;
        private string _condicionHogar;
        private string _expectativa;
        private double _ingresos;
        private bool _recibioRehabilitacion;
        private bool _candidatoTransporte;
        private string _comoSeEntero;
        private string _docAlternos;
        private string _observaciones;

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

        /*Modificado por Eliazar*/
        public string telefono
        {
            set { _telefono = value; }
            get { return _telefono; }
        }

        public string movil
        {
            set { _movil = value; }
            get { return _movil; }
        }

        public long escolaridad
        {
            set { _idEscolaridad = value; }
            get { return _idEscolaridad; }
        }

        public long profesion
        {
            set { _idProfesion = value; }
            get { return _idProfesion; }
        }

        public string lugarTrabajo
        {
            set { _lugarTrabajo = value; }
            get { return _lugarTrabajo; }
        }

        public string nombreMadre
        {
            set { _nombreMadre = value; }
            get { return _nombreMadre; }
        }

        public string nombrePadre
        {
            set { _nombrePadre = value; }
            get { return _nombrePadre; }
        }

        public string estructuraFamiliar
        {
            set { _estructuraFamiliar = value; }
            get { return _estructuraFamiliar; }
        }

        public string condicionHogar
        {
            set { _condicionHogar = value; }
            get { return _condicionHogar; }
        }

        public string expectativa
        {
            set { _expectativa = value; }
            get { return _expectativa; }
        }

        public double ingresos
        {
            set { _ingresos = value; }
            get { return _ingresos; }
        }

        public bool rehabilitacion
        {
            set { _recibioRehabilitacion = value; }
            get { return _recibioRehabilitacion; }
        }

        public bool candidatoTransporte
        {
            set { _candidatoTransporte = value; }
            get { return _candidatoTransporte; }
        }

        public string acercaDe
        {
            set { _comoSeEntero = value; }
            get { return _comoSeEntero; }
        }

        public string docsAlternos
        {
            set { _docAlternos = value; }
            get { return _docAlternos; }
        }

        public string observaciones
        {
            set { _observaciones = value; }
            get { return _observaciones; }
        }
        #endregion

        #region Constructores
        public Paciente()
        {
            Nombres = String.Empty;
            PrimerApellido = String.Empty;
            SegundoApellido = String.Empty;
            FechaNac = DateTime.Now;
            Sexo = true;
            FechaIngreso = DateTime.Now;
            Cedula = String.Empty;
            Direccion = String.Empty;
            LugarNac = String.Empty;
            Estado = String.Empty;
            entities = new teletonEntities();
        }
        #endregion

        public void asignarDatos(int centroActual, long expediente, string nombres, string primerApellido, string segundoApellido, 
            DateTime fechaNac, bool sexo, DateTime fechaIngreso, string cedula, string direccion, string lugarNac, string estado,
            byte[] foto, /*Modificado por Eliazar ->*/string telefonoCasa, string celular, long idEscolaridad, long idProfesion, string dondeTrabajo, string madre,
            string padre, string estructuraFam, string condiHogar, string expectativas, double ingreso, bool recibioReha,
            bool candidatoTrans, string acerca, string docAlter, string observ)
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

            /*Modificado por Eliazar*/
            telefono = telefonoCasa;
            movil = celular;
            escolaridad = idEscolaridad;
            profesion = idProfesion;
            lugarTrabajo = dondeTrabajo;
            nombreMadre = madre;
            nombrePadre = padre;
            estructuraFamiliar = estructuraFam;
            condicionHogar = condiHogar;
            expectativa = expectativas;
            ingresos = ingreso;
            rehabilitacion = recibioReha;
            candidatoTransporte = candidatoTrans;
            acercaDe = acerca;
            docsAlternos = docAlter;
            observaciones = observ;
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

        public string getEscolaridad(long escolaridad)
        {
            DataAccess.escolaridad esc = entities.escolaridads.FirstOrDefault(
                        P => P.id == escolaridad);
            return esc.Grado;
        }

        public string getProfesion(long profesion)
        {
            DataAccess.ocupacione ocp = entities.ocupaciones.FirstOrDefault(
                        P => P.id == profesion);
            return ocp.ocupacion;
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
                _telefono = pac.telefono_fijo;
                _movil = pac.telefono_movil;
                _idEscolaridad = pac.escolaridad;
                _idProfesion = pac.profesion;
                _lugarTrabajo = pac.lugar_trabajo;
                _nombreMadre = pac.nombre_madre;
                _nombrePadre = pac.nombre_padre;
                _estructuraFamiliar = pac.estructura_familiar;
                _condicionHogar = pac.condicion_hogar;
                _expectativa = pac.recibio_rehabilitacion_antes;
                _ingresos = Convert.ToDouble(pac.ingreso_familiar);
                _recibioRehabilitacion = Convert.ToBoolean(pac.expectativa);
                _candidatoTransporte = Convert.ToBoolean(pac.candidato_transporte);
                _comoSeEntero = pac.se_entero_teleton;
                _docAlternos = pac.documentacion;
                _observaciones = pac.observaciones;
                
                return true;
            }
            return false;
        }

        public List<string> Busqueda_pacientes(string nombre) //Retorna nombres de los pacientes
        {
            try
            {
                List<string> usrs = new List<string>();

                
                var users = from p in entities.pacientes
                            where p.nombres.Contains(nombre)
                            select new {p.expediente,p.centro_actual,p.nombres,p.primer_apellido,p.segundo_apellido};


                foreach (var u in users)
                    usrs.Add(u.expediente+ " " + u.centro_actual + " " +u.nombres+" "+u.primer_apellido+" "+u.segundo_apellido);
  
                return usrs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
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

                /*Modificado por Eliazar*/
                pac.telefono_fijo = telefono;
                pac.telefono_movil = movil;
                pac.escolaridad = escolaridad;
                pac.profesion = profesion;
                pac.lugar_trabajo = lugarTrabajo;
                pac.nombre_madre = nombreMadre;
                pac.nombre_padre = nombrePadre;
                pac.estructura_familiar = estructuraFamiliar;
                pac.condicion_hogar = condicionHogar;
                pac.recibio_rehabilitacion_antes = expectativa;
                pac.ingreso_familiar = ingresos;
                pac.expectativa = rehabilitacion;
                pac.candidato_transporte = candidatoTransporte;
                pac.se_entero_teleton = acercaDe;
                pac.documentacion = docsAlternos;
                pac.observaciones = observaciones;

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

                    /*Modificado por Eliazar*/
                    pac.telefono_fijo = telefono;
                    pac.telefono_movil = movil;
                    pac.escolaridad = escolaridad;
                    pac.profesion = profesion;
                    pac.lugar_trabajo = lugarTrabajo;
                    pac.nombre_madre = nombreMadre;
                    pac.nombre_padre = nombrePadre;
                    pac.estructura_familiar = estructuraFamiliar;
                    pac.condicion_hogar = condicionHogar;
                    pac.recibio_rehabilitacion_antes = expectativa;
                    pac.ingreso_familiar = ingresos;
                    pac.expectativa = rehabilitacion;
                    pac.candidato_transporte = candidatoTransporte;
                    pac.se_entero_teleton = acercaDe;
                    pac.documentacion = docsAlternos;
                    pac.observaciones = observaciones;

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

        /*Modificado por Eliazar*/
        public DataTable cargarEscolaridad()
        {
            teletonEntities teleton = new teletonEntities();
            ObjectQuery<escolaridad> educacion = teleton.escolaridads;

            DataTable resultset = new DataTable();

            resultset.Columns.Add("ID", typeof(long));
            resultset.Columns.Add("GRADO", typeof(string));

            //Esto devuelve toda la data de la tabla faq!!!
            IQueryable<escolaridad> escolaridad = from fila in educacion
                                           select fila;

            string[] array = new string[2];
            
            foreach (var filaResultado in escolaridad)
            {
                array[0] = Convert.ToString(filaResultado.id);
                array[1] = Convert.ToString(filaResultado.Grado);

                resultset.LoadDataRow(array, false);
            }

            return resultset;
        }

        public DataTable cargarOcupaciones()
        {
            teletonEntities teleton = new teletonEntities();
            ObjectQuery<ocupacione> ocupaciones = teleton.ocupaciones;

            DataTable resultset = new DataTable();

            resultset.Columns.Add("ID", typeof(long));
            resultset.Columns.Add("OCUPACION", typeof(string));

            //Esto devuelve toda la data de la tabla faq again!!!
            IQueryable<ocupacione> profesion = from fila in ocupaciones
                                               select fila;

            string[] array = new string[2];

            foreach (var filaResultado in profesion)
            {
                array[0] = Convert.ToString(filaResultado.id);
                array[1] = Convert.ToString(filaResultado.ocupacion);

                resultset.LoadDataRow(array, false);
            }

            return resultset;
        }

        public int verificarPrefijo(int expediente,int prefijo)
        {
            var query = from pac in entities.pacientes
                        where pac.expediente==expediente
                        select new {pac.prefijo};
            if (query.ToList().Count == 0)
                return -1;
            else
            {
                foreach (var us in query)
                {
                    if (us.prefijo == prefijo)
                        return 1;
                }
            }
                return 0;
        }
        
    }
}
