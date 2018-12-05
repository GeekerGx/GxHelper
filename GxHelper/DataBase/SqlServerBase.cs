using System.Data;
using System.Data.SqlClient;

namespace GxHelper.DataBase
{
    class SqlServerBase : IDBBase
    {
        public IDbConnection CreateConnection(string strConn)
        {
            return new SqlConnection(strConn);
        }
    }
}
