using System.Data;
using MySql.Data.MySqlClient;

namespace GxHelper.DataBase
{
    class MySqlBase : IDBBase
    {
        public IDbConnection CreateConnection(string strConn)
        {
            return new MySqlConnection(strConn);
        }
    }
}