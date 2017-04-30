using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace XMLDB
{
    public class XmlDbPersistence : IDbPersistence
    {
#if (DEBUG)
        string path = "Data.db"; 
#else
        string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\UWF\\Blackjack\\Data.db";
#endif
        public DataSet ds { get; }

        public XmlDbPersistence()
        {
            ds = new DataSet();
        }

        public DataRow[] query(String table, String query)
        {
            return ds.Tables[table].Select(query);
        }

        public void insert(String table, DataRow row)
        {
            ds.Tables[table].Rows.Add(row);
        }

        public void update(String table, String query, String columnValues)
        {
            String columnName;
            String columnValue;

            DataRow[] rows = ds.Tables[table].Select(query);

            foreach (DataRow row in rows)
            {
                foreach (String cv in columnValues.Split(','))
                {
                    columnName = cv.Split('=')[0];
                    columnValue = cv.Split('=')[1];
                    row[columnName] = Convert.ChangeType(columnValue, ds.Tables[table].Columns[columnName].DataType);
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
            ds.WriteXml(path, XmlWriteMode.WriteSchema);
        }

        public bool load()
        {
            try
            {
                ds.ReadXml(path, XmlReadMode.ReadSchema);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public void initialize()
        {
            DataTable dt = new DataTable();
            dt.TableName = "Players";

            DataColumn id = new DataColumn();
            id.AutoIncrement = true;
            id.AutoIncrementSeed = 1;
            id.AutoIncrementStep = 1;
            id.Unique = true;
            id.ColumnName = "ID";
            id.DataType = typeof(Int32);

            dt.Columns.Add(id);

            DataColumn name = new DataColumn();
            name.ColumnName = "Name";
            name.DataType = typeof(String);

            dt.Columns.Add(name);

            DataColumn balance = new DataColumn();
            balance.ColumnName = "Balance";
            balance.DataType = typeof(Int32);

            dt.Columns.Add(balance);

            ds.Tables.Add(dt);
        }
    }
}

