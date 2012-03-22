using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data;
using System.Data.Objects;


namespace BL
{
    public class Areas
    {
        #region Entities
        DataAccess.teletonEntities entities;
        #endregion

        public Areas()
        {
            entities = new teletonEntities();
        }

        public DataTable listAreas()
        {
            DataTable list = new DataTable();
            list.Columns.Add("id");
            list.Columns.Add("orden");
            list.Columns.Add("area");

            try
            {
                var query = from x in entities.areas
                            select x;

                foreach (area row in query)
                {
                    list.Rows.Add(row.id, row.orden, row.area1);
                }
                return list;
            }
            catch
            {
                return null;
            }
        }

        public bool deleteAreas(int _area)
        {
            try
            {
                var query = from c in entities.historials
                            where c.area == _area
                            select new { c.area };
                if (query.Count() <= 0)
                {
                    var query1 = from c in entities.areas
                                where c.id == _area
                                select c;
                    if (query1.Count() > 0)
                    {
                        DataAccess.area l_area = query1.First();
                        entities.DeleteObject(l_area);
                        entities.SaveChanges();
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public bool insertAreas(string _area, string _orden)
        {
            try
            {
                DataAccess.area c_area = new DataAccess.area();
                c_area.area1 = _area;
                c_area.orden = Convert.ToInt32(_orden);
                entities.areas.AddObject(c_area);
                entities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateAreas(int _id,string _area, int _orden)
        {
            try
            {
                var query = (from x in entities.areas
                            where x.id == _id
                            select x).First();
                DataAccess.area c_area = query;
                c_area.area1 = _area;
                c_area.orden = _orden;
                entities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
