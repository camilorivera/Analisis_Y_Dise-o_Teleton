using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{

    public class Citas
    {
        private DataAccess.teletonEntities entities = new DataAccess.teletonEntities();
        public  void NuevaCitaMedica(DateTime fecha, String nombreDoctor, int prefijo, long expediente,String tipo)
        {
            try
            {
                string nombre=new Usuarios().RetrieveUserName(nombreDoctor);
                
                DataAccess.citas_doctor  nuevaCita = new DataAccess.citas_doctor();
                nuevaCita.doctor_username = nombre;
                nuevaCita.fecha_hora = fecha;
                nuevaCita.prefijo = prefijo;
                nuevaCita.expediente = expediente;
                nuevaCita.tipo = tipo;

                entities.citas_doctor.AddObject(nuevaCita);
                entities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " --BL.Citas en Nueva Cita Medica");
            }
        }

        public void NuevaCitaTerapia(DateTime fecha, String nombreTerapeuta, int prefijo, long expediente, 
            TimeSpan horaInicio, TimeSpan horaFinal)
        {
            try
            {
                string nombre = new Usuarios().RetrieveUserName(nombreTerapeuta);

                DataAccess.citas_terapia nuevaCita = new DataAccess.citas_terapia();
                nuevaCita.user = nombre;
                nuevaCita.fecha = fecha;
                nuevaCita.prefijo = prefijo;
                nuevaCita.expediente = expediente;
                nuevaCita.hora_inicio = horaInicio;
                nuevaCita.hora_final = horaFinal;
                nuevaCita.atendido = false;

                entities.citas_terapia.AddObject(nuevaCita);
                entities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean existeCitaMedicaProgramada(DateTime fecha, String nombreDoctor)
        {
            Boolean existeCita;
            try
            {
                Usuarios user = new Usuarios();

                String userName = user.RetrieveUserName(nombreDoctor);
                var query = from citas in entities.citas_doctor
                            where citas.fecha_hora == fecha && citas.doctor_username == userName
                            select citas;

                existeCita = query.Any();

                return existeCita;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " --BL.Citas en existeCitaMedicaProgramada");
            }
        }

        public Boolean existeCitaTerapiaProgramada(DateTime fecha, TimeSpan horaInicio, TimeSpan horaFinal, String nombreTerapeuta)
        {
            Boolean existeCita;
            try
            {
                Usuarios user = new Usuarios();

                String userName = user.RetrieveUserName(nombreTerapeuta);
                
                //Verificamos que la hora inicio no esta tomada
                var query1 = from citas_t in entities.citas_terapia
                             where horaInicio>=citas_t.hora_inicio && horaInicio <= citas_t.hora_final && citas_t.fecha == fecha.Date
                             && citas_t.user == userName
                             select citas_t;

                //Verificamos que la hora final no esta tomada
                var query2 = from citas_t in entities.citas_terapia
                             where horaFinal >= citas_t.hora_inicio && horaFinal <= citas_t.hora_final && citas_t.fecha == fecha.Date
                             && citas_t.user == userName
                             select citas_t;

                existeCita = query1.Any() || query2.Any();

                return existeCita;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable getCitasMedicas(string username, DateTime fechai, DateTime fechaf)
        {
            var query = from c in entities.citas_doctor
                        where c.fecha_hora > fechai && c.fecha_hora < fechaf && c.doctor_username == username
                        select new { c.expediente, c.fecha_hora };
            return query;
        }

        //Sobrecarga de Funciones para obtener la cita de terapia basados en distintos queries

        public IQueryable ObtenerCitasTerapia(DateTime fecha, String nombreUsuario, int prefijo)
        {
            Usuarios user = new Usuarios();
            String userName = user.RetrieveUserName(nombreUsuario);
            try
            {
                var query = from citas in entities.citas_terapia
                            where citas.fecha == fecha && citas.user == userName && citas.prefijo == prefijo
                            select new { citas.id, citas.expediente, citas.prefijo, citas.user, citas.hora_inicio, citas.hora_final, citas.fecha, citas.atendido };

                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable ObtenerCitasTerapia(DateTime fecha, String nombreUsuario, int prefijo, long expediente)
        {
            Usuarios user = new Usuarios();
            String userName = user.RetrieveUserName(nombreUsuario);
            try
            {
                var query = (from citas in entities.citas_terapia
                             where citas.fecha == fecha && citas.user == userName && citas.prefijo == prefijo && citas.expediente == expediente
                             select new { citas.id, citas.expediente, citas.prefijo, citas.user, citas.hora_inicio, citas.hora_final, citas.fecha, citas.atendido });

                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
