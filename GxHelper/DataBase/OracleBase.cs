using System.Data;
using System.Data.OracleClient;

namespace GxHelper.DataBase
{
    class OracleBase:IDBBase
    {
        public IDbConnection CreateConnection(string strConn)
        {
            return new OracleConnection(strConn);
        }
    }
}
