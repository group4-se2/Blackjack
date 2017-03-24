using System;
using System.Data;

namespace XMLDB
{
    public interface IDbPersistence
    {
        DataSet ds { get; }

        DataRow[] query(String table, String query);

        void insert(String table, DataRow row);

        void update(String table, int id, DataRow row);

        void delete(String table, int id);
        
        void save();
        
        void load();
    }
}
