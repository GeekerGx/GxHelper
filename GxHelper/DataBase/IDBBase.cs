using System.Data;

namespace GxHelper.DataBase
{
    /// <summary>
    /// 数据库工厂
    /// v_0.0.0
    /// </summary>
    public interface IDBBase
    {
        /// <summary>
        /// 创建Connection
        /// </summary>
        /// <param name="strConn"></param>
        /// <returns></returns>
        IDbConnection CreateConnection(string strConn);
    }
}
