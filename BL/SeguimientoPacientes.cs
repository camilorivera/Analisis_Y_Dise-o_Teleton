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
    public class SeguimientoPacientes
    {

        private string _actividadesParticipacion;
        private string _estructura;

        public string ActividadesParticipacion
        {
            get { return _actividadesParticipacion; }
            set { _actividadesParticipacion = value; }
        }

        public string Estructura
        {
            get { return _estructura; }
            set { _estructura = value; }
        }

        #region Variables
        DataAccess.teletonEntities entities;
        string fecha;
        #endregion

        #region Constructor
        public SeguimientoPacientes()
        {
            entities = new teletonEntities();
            DateTime d = DateTime.Now;
            fecha = d.ToShortDateString();
            d.ToString();
            /*fecha = DateTime.Now.Year.ToString();
            fecha = fecha + "-" + (DateTime.Now.Month < 10 ? "0" : "") + DateTime.Now.Month.ToString();
            fecha = fecha + "-" + (DateTime.Now.Day < 10 ? "0" : "") + DateTime.Now.Day.ToString();*/
        }
        #endregion

        #region Funciones
        
        public string GetFecha()
        {
            return fecha;
        }

        #region Retrieve_GetID

        public string getDiagnostico(long exp) 
        {
            var query = from p in entities.evoluciones
                        where exp == p.expediente && p.condicion.simbolo == "N"
                        select p.diagnostico.diagnostico1;

            return query.FirstOrDefault();    
        }

        public List<String> RetrievePatologias() //Retorna Una Lista de Patologias
        {
            var query = from p in entities.diagnosticos orderby p.diagnostico1 select p;
            List<string> Diag = new List<string>();
            foreach (diagnostico nombre in query)
                Diag.Add(nombre.diagnostico1);

            return Diag;
        }

        public Int32 GetPatologiasId(string nom_pat)
        {
            int id = 0;
            var query = from diag in entities.diagnosticos
                        where nom_pat == diag.diagnostico1
                        select diag.id;

            id = Convert.ToInt32(query.FirstOrDefault());

            return id;
        }

        public List<String> RetrieveClasificacionDelPaciente() 
        {
            var query = from p in entities.clasificacion_paciente select p;
            List<String> cp = new List<string>();
            foreach (clasificacion_paciente nom in query)
                cp.Add(nom.clasificacion);

            return cp;
        }

        public Int32 GetClasificacionId(string clasif)
        {
            int id = 0;
            var query = from diag in entities.clasificacion_paciente
                        where clasif == diag.clasificacion
                        select diag.id;

            id = Convert.ToInt32(query.FirstOrDefault());

            return id;
        }

        public List<String> RetrieveGrado()
        {
            var query = from p in entities.escolaridads select p;
            List<String> grd = new List<string>();
            foreach (escolaridad nom in query)
                grd.Add(nom.Grado);

            return grd;
        }

        public Int32 GetGradoId(string grado)
        {
            int id = 0;
            var query = from diag in entities.escolaridads
                        where grado == diag.Grado
                        select diag.id;

            id = Convert.ToInt32(query.FirstOrDefault());
            return id;
        }

        public List<String> RetrieveOcupaciones()
        {
            var query = from p in entities.ocupaciones select p;
            List<String> ocu = new List<string>();
            foreach (ocupacione nom in query)
                ocu.Add(nom.ocupacion);

            return ocu;
        }

        public Int32 GetOcupacionId(string ocu)
        {
            int id = 0;
            var query = from diag in entities.ocupaciones
                        where ocu == diag.ocupacion
                        select diag.id;

            id = Convert.ToInt32(query.FirstOrDefault());
            return id;
        }

        public List<String> RetrieveCondiciones()
        {
            var query = from p in entities.condicions select p;
            List<String> con = new List<string>();
            foreach (condicion nom in query)
                con.Add(nom.condicion1);

            return con;
        }

        public string GetCondicionId(string con)
        {
            string id = "";
            var query = from diag in entities.condicions
                        where con == diag.condicion1
                        select diag.simbolo;

            id = query.FirstOrDefault();
            return id;
        }

        public string GetProcedenciaId(string proc)
        {
            string id = "";
            var query = from diag in entities.procedencias
                        where proc == diag.procedencia1
                        select diag.simbolo;

            id = query.FirstOrDefault();
            return id;
        }

        public List<String> RetrieveReferencias()
        {
            var query = from p in entities.referencias select p;
            List<String> refe = new List<string>();
            foreach (referencia nom in query)
                refe.Add(nom.descripcion);

            return refe;
        }

        public Int32 GetReferenciaId(string refe)
        {
            int id = 0;
            var query = from diag in entities.referencias
                        where refe == diag.descripcion
                        select diag.id;

            id = Convert.ToInt32(query.FirstOrDefault());
            return id;
        }

        public List<String> RetrieveTipoDanio()
        {
            var query = from p in entities.tipo_daño select p;
            List<String> td = new List<string>();
            foreach (tipo_daño nom in query)
                td.Add(nom.tipo);

            return td;
        }

        public Int32 GetTipoDanioId(string tipo)
        {
            int id = 0;
            var query = from diag in entities.tipo_daño
                        where tipo == diag.tipo
                        select diag.id;

            id = Convert.ToInt32(query.FirstOrDefault());
            return id;
        }

        public List<String> RetrieveAyudasTecnicas()
        {
            var query = from p in entities.ayudas_tecnicas select p;
            List<String> ayte = new List<string>();
            foreach (ayudas_tecnicas nom in query)
                ayte.Add(nom.ayuda);

            return ayte;
        }

        public Int32 GetAyudaTecnicaId(string ayudaTec)
        {
            int id = 0;
            var query = from diag in entities.ayudas_tecnicas
                        where ayudaTec == diag.ayuda
                        select diag.id;

            id = Convert.ToInt32(query.FirstOrDefault());
            return id;
        }
        #endregion

        public IQueryable RetrievePacientesDiario(int centroid) //Retorna un dataset de evoluciones
        {
            DateTime d = DateTime.Parse(fecha);

            var query = from p in entities.evoluciones
                        join e in entities.pacientes
                        on p.expediente equals e.expediente
                        join a in entities.diagnosticos
                        on p.id_diagnostico equals a.id
                        join m in entities.usuarios
                        on p.evaluador equals m.username
                        join j in entities.empleados
                        on m.empleado equals j.id
                        where p.fecha == d && p.prefijo==centroid
                        select new { p.fecha, p.expediente, a.diagnostico1 , nombres = j.nombres+" "+j.primer_apellido+" "+j.segundo_apellido , p.notas, NOMBRE = e.nombres , e.primer_apellido };

            return query;
        }

        public IQueryable RetrievePacientesDiario2(int centroid, string doctor) //Retorna un dataset de evoluciones
        {
            DateTime d = DateTime.Parse(fecha);

            var query = from p in entities.evoluciones
                        join e in entities.pacientes
                        on p.expediente equals e.expediente
                        join a in entities.diagnosticos
                        on p.id_diagnostico equals a.id
                        join m in entities.usuarios
                        on p.evaluador equals m.username
                        where m.username == doctor
                        join j in entities.empleados
                        on m.empleado equals j.id
                        where p.fecha == d && p.prefijo == centroid
                        select new { p.fecha, p.expediente, a.diagnostico1, nombres = j.nombres + " " + j.primer_apellido + " " + j.segundo_apellido, p.notas, NOMBRE = e.nombres, e.primer_apellido };

            return query;
        }

        public IQueryable BusquedaRapida(string nombres, string apellido, string segundoapellido, string cedula, long centroActual)
        {
            try
            {
                var query = (from p in entities.pacientes
                             where (p.nombres.Contains(nombres) && nombres != "") && p.centro_actual == centroActual
                             select new
                             {
                                 Expediente = p.expediente,
                                 Nombre = p.nombres,
                                 PrimerApellido = p.primer_apellido,
                                 SegundoApellido = p.segundo_apellido,
                                 Cedula = p.cedula
                                 
                             }).Union
                             (from p1 in entities.pacientes
                              where (p1.primer_apellido.Contains(apellido) && apellido != "") && p1.centro_actual == centroActual
                              select new
                              {
                                  Expediente = p1.expediente,
                                  Nombre = p1.nombres,
                                  PrimerApellido = p1.primer_apellido,
                                  SegundoApellido = p1.segundo_apellido,
                                  Cedula = p1.cedula
                                  
                              }).Union
                              (from p2 in entities.pacientes
                               where (p2.segundo_apellido.Contains(segundoapellido) && segundoapellido != "") && p2.centro_actual == centroActual
                               select new
                               {
                                   Expediente = p2.expediente,
                                   Nombre = p2.nombres,
                                   PrimerApellido = p2.primer_apellido,
                                   SegundoApellido = p2.segundo_apellido,
                                   Cedula = p2.cedula
                                   
                               }).Union
                               (from p3 in entities.pacientes
                                where p3.cedula == cedula && p3.centro_actual == centroActual
                                select new
                                {
                                    Expediente = p3.expediente,
                                    Nombre = p3.nombres,
                                    PrimerApellido = p3.primer_apellido,
                                    SegundoApellido = p3.segundo_apellido,
                                    Cedula = p3.cedula
                                    
                                });
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + " --SeguimientoPacientes.cs / BusquedaRapida()");
            }
        }

        public IQueryable BusquedaporRangoFecha(DateTime fechainit, DateTime fechafin,int centroid)
        {

            var query = from p in entities.evoluciones
                        join e in entities.pacientes
                        on p.expediente equals e.expediente
                        join a in entities.diagnosticos
                        on p.id_diagnostico equals a.id
                        where p.fecha.Year >= fechainit.Year && p.fecha.Month >= fechainit.Month && p.fecha.Day >= fechainit.Day &&
                              p.fecha.Year <= fechafin.Year && p.fecha.Month <= fechafin.Month && p.fecha.Day <= fechafin.Day && p.prefijo==centroid
                        select new { p.fecha, p.expediente, a.diagnostico1, p.evaluador, p.notas, e.nombres, e.primer_apellido };

            return query;

        }

        public IQueryable BusquedaporRangoFecha2(DateTime fechainit, DateTime fechafin, int centroid, string doctor)
        {

            DateTime fechaFinal = new DateTime(fechafin.Year, fechafin.Month, fechafin.Day, 23, 59, 59);

            switch (doctor)
            {
                case "todos":
                    var query = from p in entities.evoluciones

                                join e in entities.clasificacion_paciente
                                on p.id_clasificacion_paciente equals e.id

                                join doc in
                                    (from temp in entities.usuarios
                                     join emp in entities.empleados
                                     on temp.empleado equals emp.id
                                     where emp.puesto == 16
                                     select new { temp.username, emp.nombres, emp.primer_apellido, emp.segundo_apellido })
                                on p.evaluador equals doc.username

                                join b in entities.pacientes
                                on p.expediente equals b.expediente

                                join r in entities.condicions
                                on p.id_condicion equals r.simbolo

                                join a in entities.diagnosticos
                                on p.id_diagnostico equals a.id

                                join d in entities.tipo_daño
                                on p.id_tipo_daño equals d.id

                                join t in entities.procedencias
                                on p.id_procedencia equals t.simbolo

                                join es in entities.escolaridads
                                on p.id_escolaridad equals es.id

                                join ay in entities.ayudas_tecnicas
                                on p.id_ayudas_tecnicas equals ay.id

                                join oc in entities.ocupaciones
                                on p.id_ocupacion equals oc.id

                                where ((p.fecha.CompareTo(fechainit) == 0) || (p.fecha.CompareTo(fechainit) > 0)) &&
                                        ((p.fecha.CompareTo(fechaFinal) == 0) || (p.fecha.CompareTo(fechaFinal) < 0)) && (p.prefijo == centroid)

                                select new
                                {
                                    p.fecha,
                                    p.expediente,
                                    e.clasificacion,
                                    b.nombres,
                                    b.primer_apellido,
                                    b.segundo_apellido,
                                    genero = (b.sexo ? "Masculino" : "Femenino"),
                                    nombreDoc = doc.nombres,
                                    apeDoc = doc.primer_apellido,
                                    ape2Doc = doc.segundo_apellido,
                                    r.condicion1,
                                    b.cedula,
                                    p.notas,
                                    codigoInternacional = a.codigoInter,
                                    diagnostico1 = a.diagnostico1,
                                    d.tipo,
                                    t.procedencia1,
                                    p.funcion_estructura,
                                    es.Grado,
                                    ay.ayuda,
                                    oc.ocupacion,
                                    p.años_tiempo_discapacidad,
                                    p.meses_tiempo_discapacidad,
                                    p.dias_tiempo_discapacidad,
                                    p.años_TSTDL,
                                    p.meses_TSTDL,
                                    p.dias_TSTDL,
                                    p.eteologia
                                };
                    return query;
                    break;
                
                default:
                    var query2 = from p in entities.evoluciones

                                join e in entities.clasificacion_paciente
                                on p.id_clasificacion_paciente equals e.id

                                join doc in
                                    (from temp in entities.usuarios
                                     join emp in entities.empleados
                                     on temp.empleado equals emp.id
                                     where emp.puesto == 16
                                     select new { temp.username, emp.nombres, emp.primer_apellido, emp.segundo_apellido })
                                on p.evaluador equals doc.username

                                join b in entities.pacientes
                                on p.expediente equals b.expediente

                                join r in entities.condicions
                                on p.id_condicion equals r.simbolo

                                join a in entities.diagnosticos
                                on p.id_diagnostico equals a.id

                                join d in entities.tipo_daño
                                on p.id_tipo_daño equals d.id

                                join t in entities.procedencias
                                on p.id_procedencia equals t.simbolo

                                join es in entities.escolaridads
                                on p.id_escolaridad equals es.id

                                join ay in entities.ayudas_tecnicas
                                on p.id_ayudas_tecnicas equals ay.id

                                join oc in entities.ocupaciones
                                on p.id_ocupacion equals oc.id

                                where ((p.fecha.CompareTo(fechainit) == 0) || (p.fecha.CompareTo(fechainit) > 0)) &&
                                        ((p.fecha.CompareTo(fechaFinal) == 0) || (p.fecha.CompareTo(fechaFinal) < 0)) && (p.prefijo == centroid)
                                        && doc.username == doctor

                                select new
                                {
                                    p.fecha,
                                    p.expediente,
                                    e.clasificacion,
                                    b.nombres,
                                    b.primer_apellido,
                                    b.segundo_apellido,
                                    genero = (b.sexo ? "Masculino" : "Femenino"),
                                    nombreDoc = doc.nombres,
                                    apeDoc = doc.primer_apellido,
                                    ape2Doc = doc.segundo_apellido,
                                    r.condicion1,
                                    b.cedula,
                                    p.notas,
                                    codigoInternacional = a.codigoInter,
                                    diagnostico1 = a.diagnostico1,
                                    d.tipo,
                                    t.procedencia1,
                                    p.funcion_estructura,
                                    es.Grado,
                                    ay.ayuda,
                                    oc.ocupacion,
                                    p.años_tiempo_discapacidad,
                                    p.meses_tiempo_discapacidad,
                                    p.dias_tiempo_discapacidad,
                                    p.años_TSTDL,
                                    p.meses_TSTDL,
                                    p.dias_TSTDL,
                                    p.eteologia
                                };
                        return query2;
                    break;
            }

        }

        public bool VerificarPacientes(string numexpediente) {
            try
            {

                bool found;
                long numexp = Convert.ToInt64(numexpediente);

                var query = (from p in entities.pacientes
                             where p.expediente == numexp
                             select p.nombres);

                if (!query.Any())
                {
                    found = false;
                }
                else
                {
                    found = true;
                }
                return found;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
        }

        public bool VerificarPacienteAlta(string numexpediente)//verifica si esta de alta 
        {
            try
            {

                bool found;
                long numexp = Convert.ToInt64(numexpediente);

                var query = (from p in entities.pacientes
                             where p.expediente == numexp && p.activo == true
                             select p.nombres);

                if (!query.Any())
                {
                    found = false;
                }
                else
                {
                    found = true;
                }
                return found;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
        }

        public int VerificarExpPorCentro(int numexp) {

            long numexpe = Convert.ToInt64(numexp);
            var query = from p in entities.pacientes
                        where p.expediente == numexpe
                        select p.centro_actual;

            int centroactual = Convert.ToInt32(query.First().ToString());
            return centroactual;
        }

        public string NombrePaciente(string numexp) {

            long numexpe = Convert.ToInt64(numexp);

            var query = (from p in entities.pacientes
                         where p.expediente == numexpe
                         select p.nombres).First();

            DataAccess.evolucione evo = new DataAccess.evolucione();

            return query.ToString();
        
        }

         public string EstructuraPaciente(long numexp) {

            long numexpe = Convert.ToInt64(numexp);

            var query = (from p in entities.evoluciones
                        where numexp == p.expediente
                        select p.funcion_estructura).FirstOrDefault();   

            return query.ToString();
        }

         public string ActividadesPaciente(long numexp) {

            long numexpe = Convert.ToInt64(numexp);

            var query = (from p in entities.evoluciones
                        where numexp == p.expediente
                        select p.funcion_estructura).FirstOrDefault();

            return query.ToString();  
        }

      
        public string NumIdentidad(string numexp)
        {

            long numexpe = Convert.ToInt64(numexp);

            var query = (from p in entities.pacientes
                         where p.expediente == numexpe
                         select p.cedula).First();

            return query.ToString();
        }

        public void GuardarSeguimientoPacientes(int id, int prefix, int numexp, string doctor, string patologia, string observacion,
                                                string clasifi,string grado,string ocupacion,string condicion,string referencia,
                                                string tipoDanio, string ayTec,string funEstructura,string Eteolo,string procedencia,
                                                int TDAnios,int TDMeses,int TDDias, int TSAnios,int TSMeses,int TSDias, string actParticipacion)
        {

            try
            {
                int idpatologia = GetPatologiasId(patologia);
                int idClass = GetClasificacionId(clasifi);
                int idGrado = GetGradoId(grado);
                int idOcupacion = GetOcupacionId(ocupacion);
                string idCondicion = GetCondicionId(condicion);
                string idProcedencia = GetProcedenciaId(procedencia);
                int idTipoDanio = GetTipoDanioId(tipoDanio);
                int idAyudaTecnica = GetAyudaTecnicaId(ayTec);

                DateTime date = DateTime.Parse(fecha);
                DataAccess.evolucione evo = new DataAccess.evolucione();

                evo.id = id;
                evo.fecha = date;
                evo.prefijo = prefix;
                evo.expediente = numexp;
                evo.id_diagnostico = idpatologia;
                evo.evaluador = doctor;
                evo.notas = observacion;
                evo.id_clasificacion_paciente = idClass;
                evo.id_escolaridad = idGrado;
                evo.id_ocupacion = idOcupacion;
                evo.id_tipo_daño = idTipoDanio;
                evo.id_ayudas_tecnicas = idAyudaTecnica;
                evo.funcion_estructura = funEstructura;
                evo.actividades_participacion = actParticipacion;
                evo.eteologia = Eteolo;

                // QUE ONDAS CON ESTO
                evo.id_condicion = idCondicion;
                // FALTA PROCEDENCIA
                evo.id_procedencia = idProcedencia;
                
                evo.años_tiempo_discapacidad = (long)TDAnios;
                evo.meses_tiempo_discapacidad = (long)TDMeses;
                evo.dias_tiempo_discapacidad = (long)TDDias;

                evo.dias_TSTDL = (long)TSDias;
                evo.meses_TSTDL = (long)TSMeses;
                evo.años_TSTDL = (long)TSAnios;
                


                entities.evoluciones.AddObject(evo);
                entities.SaveChanges();
            }
            catch (Exception err)
            {
                throw new Exception(err.ToString() + "--SeguimientoPacientes.cs / GuardarSeguimientoPacientes()");
            }
        }
    }
        #endregion
      
}
