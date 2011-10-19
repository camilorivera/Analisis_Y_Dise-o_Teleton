using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data;
using System.Data.Objects;

namespace BL
{
    public class Centro
    {
        #region Variables
        DataAccess.teletonEntities entities;
        centro center;
        #endregion

        public Centro()
        {
            entities = new teletonEntities();
        }

        public long getNext(Int64 id)
        {
            try
            {
                var query = from c in entities.centros
                            where id == c.id
                            select c.siguiente_expediente;
                return Convert.ToInt64(query.FirstOrDefault());
            }
            catch (Exception err)
            {
                throw new Exception(err.ToString() + "--centros.cs / GetNext(Int64)");
            }
        }

        public string getLugar(long id)
        {
            try
            {
                var query = from c in entities.centros
                            where id == c.id
                            select c.lugar;
                return query.First();
            }
            catch (Exception err)
            {
                throw new Exception(err.ToString() + "--centros.cs / GetLugar(long)");
            }
        }
    }
}
