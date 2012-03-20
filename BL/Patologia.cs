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
    public class Patologia
    {
        #region Variables
        DataAccess.teletonEntities entities;
        #endregion

        #region Constructor
        public Patologia()
        {
            entities = new teletonEntities();
        }
        #endregion

        
        public List<String> CargarDiagnostico() //Retorna Una Lista de las Patologias
        {
            var query = from p in entities.diagnosticos select p;
            List<string> Pat = new List<string>();
            foreach (diagnostico patologia in query)
                Pat.Add(patologia.diagnostico1);
            return Pat;
        }

        public void GuardarPatologia(int id, string diagnostico,string cod)
        {
            try
            {
                DataAccess.diagnostico diag = new DataAccess.diagnostico();
                diag.id = id;
                diag.diagnostico1 = diagnostico;
                diag.codigoInter = cod;

                entities.diagnosticos.AddObject(diag); //Se guarda en memoria
                entities.SaveChanges();//Se guarda en la base de datos

            }
            catch (Exception err)
            {

                throw new Exception(err.ToString() + "--Diagnostico.cs / GuardarDiagnostico()");
            }

        }

        /// <summary>
        /// Verifica si una patologia puede ser eliminada
        /// </summary>
        /// <param name="id">id de la patologia</param>
        /// <returns>true -> puede ser eliminada\nfalse -> no puede ser eliminada</returns>
        public bool EliminarPatologia(int _id)
        {
            try
            {
                var paciente = (from pac in entities.pacientes
                                where pac.diagnostico == _id
                                select pac.diagnostico);

                if (paciente.ToArray().Length == 0)
                {
                    var evolucion = (from evo in entities.evoluciones
                                     where evo.id_diagnostico == _id
                                     select evo.id_diagnostico);
                    if (evolucion.ToArray().Length == 0)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

    }
}
