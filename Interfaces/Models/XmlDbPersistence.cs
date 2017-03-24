using System;
using System.Data;
using System.Linq;

namespace XMLDB
{
    public class XmlDbPersistence : IDbPersistence
    {
        public DataSet ds  { get; }
        
        public DataRow[] query(String table, String query)
        {
            return ds.Tables[table].Select(query);
        }
        
        public void insert(String table, DataRow row)
        {
            ds.Tables[table].Rows.Add(row);
        }
        
        public void update(String table, int id, DataRow row)
        {
            DataRow oldRow = ds.Tables[table].Rows.Find(id);
            for (int i = 0; i < oldRow.ItemArray.Length; i++)
            {
                if (row[i] != oldRow[i])
                {
                    oldRow[i] = row[i];
                }
            }

        }
        
        public void delete(String table, int id)
        {
            ds.Tables[table].Rows.Find(id).Delete();
            ds.Tables[table].AcceptChanges();
        }
        
        public void save()
        {
            ds.AcceptChanges();
            ds.WriteXml("Data.db", XmlWriteMode.WriteSchema);
        }
        
        public void load()
        {
            ds.ReadXml("Data.db", XmlReadMode.ReadSchema);
        }
    }
}

