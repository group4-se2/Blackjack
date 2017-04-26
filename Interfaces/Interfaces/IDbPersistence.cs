using System;
using System.Data;

namespace XMLDB
{
    public interface IDbPersistence
    {
        DataSet ds { get; }

        DataRow[] query(String table, String query);

        void insert(String table, DataRow row);

        void update(String table, String query, String columnValues);

        void delete(String table, int id);
        
        void save();
        
        bool load();

        void initialize();
    }
}
