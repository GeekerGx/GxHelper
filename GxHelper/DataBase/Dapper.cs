using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace GxHelper.DataBase
{
    /// <summary>
    /// 使用Dapper操作数据库
    /// v0.1.0
    /// </summary>
    public class DapperHelper : DBbase
    {

        #region 域

        private static DapperHelper _Dapper = null;

        #endregion

        #region 公共方法

        /// <summary>
        /// 获得对象服务。
        /// </summary>
        /// <returns></returns>
        public static DapperHelper GetService()
        {
            if (_Dapper == null)
            {
                _Dapper = new DapperHelper();
            }
            return _Dapper;
        }

        /// <summary>
        /// 执行数据库查询语句，返回对应对象列表。
        /// </summary>
        /// <typeparam name="T">转成实体</typeparam>
        /// <param name="sql">sql查询语句</param>
        /// <param name="sqlParam">参数</param>
        /// <returns></returns>
        public IEnumerable<T> Query<T>(string sql, object sqlParam = null)
        {
            using (var connection = GetOpenConnection())
            {
                return connection.Query<T>(sql, sqlParam);
            }
        }

        /// <summary>
        /// 执行数据库语句，返回被操作的条数。
        /// </summary>
        /// <param name="Sql">sql执行语句</param>
        /// <param name="sqlParam">参数</param>
        /// <returns></returns>
        public int Execute(string sql, object sqlParam = null)
        {
            using (var connection = GetOpenConnection())
            {
                int res = connection.Execute(sql, sqlParam);
                return res;
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 私有化构造函数，防止在其他地方被实例化。
        /// </summary>
        private DapperHelper()
        {

        }

        #endregion

    }
}