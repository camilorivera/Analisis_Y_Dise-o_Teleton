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

        public void GuardarPatologia(int id, string diagnostico)
        {
            try
            {
                DataAccess.diagnostico diag = new DataAccess.diagnostico();
                diag.id = id;
                diag.diagnostico1 = diagnostico;

                entities.diagnosticos.AddObject(diag); //Se guarda en memoria
                entities.SaveChanges();//Se guarda en la base de datos

            }
            catch (Exception err)
            {

                throw new Exception(err.ToString() + "--Diagnostico.cs / GuardarDiagnostico()");
            }

        }

    }
}
