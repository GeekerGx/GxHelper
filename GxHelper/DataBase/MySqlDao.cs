using System.Data;
using MySql.Data.MySqlClient;

namespace GxHelper.DataBase
{
    class MySqlDao : IDataBaseDao
    {
        public IDbConnection CreateConnection(string strConn)
        {
            return new MySqlConnection(strConn);
        }
        public IDbDataAdapter CreateDataAdapter()
        {
            return new MySqlDataAdapter();
        }
        public IDbCommand CreateCommand()
        {
            return new MySqlCommand();
        }

    }
}