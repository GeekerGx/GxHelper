using System.Data;
using System.Data.OracleClient;

namespace GxHelper.DataBase
{
    class OracleDao:IDataBaseDao
    {
        public IDbConnection CreateConnection(string strConn)
        {
            return new OracleConnection(strConn);
        }
        public IDbDataAdapter CreateDataAdapter()
        {
            return new OracleDataAdapter();
        }
        public IDbCommand CreateCommand()
        {
            return new OracleCommand();
        }

    }
}
