using System.Data;
using System.Data.SqlClient;

namespace GxHelper.DataBase
{
    class SqlServerDao : IDataBaseDao
    {
        public IDbConnection CreateConnection(string strConn)
        {
            return new SqlConnection(strConn);
        }
        public IDbDataAdapter CreateDataAdapter()
        {
            return new SqlDataAdapter();
        }
        public IDbCommand CreateCommand()
        {
            return new SqlCommand();
        }

    }
}
