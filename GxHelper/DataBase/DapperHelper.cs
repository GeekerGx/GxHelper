using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace GxHelper.DataBase
{
    /// <summary>
    /// 使用Dapper操作数据库
    /// v0.1.0
    /// </summary>
    public static class DapperHelper
    {
        private static DataBaseService _Service = null;
        private static DataBaseService Service
        {
            get
            {
                if (_Service == null)
                {
                    _Service = DataBaseService.GetService();
                }
                return _Service;
            }
        }

        /// <summary>
        /// 执行数据库查询语句，返回对应对象列表。
        /// </summary>
        /// <typeparam name="T">转成实体</typeparam>
        /// <param name="sql">sql查询语句</param>
        /// <param name="sqlParam">参数</param>
        /// <returns></returns>
        public static IEnumerable<T> Query<T>(string sql, object sqlParam = null)
        {
            using (var connection = Service.GetOpenConnection())
            {
                return connection.Query<T>(sql, sqlParam);
            }
        }

        public static DataSet QueryDataSet(string sql)
        {
            return Service.ExcuteQuery(sql);
        }
        public static DataTable QueryDataTable(string sql)
        {
            var ds = QueryDataSet(sql);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            throw new Exception("未查找出任何数据源！");
        }

        /// <summary>
        /// 执行数据库语句，返回被操作的条数。
        /// </summary>
        /// <param name="Sql">sql执行语句</param>
        /// <param name="sqlParam">参数</param>
        /// <returns></returns>
        public static int Execute(string sql, object sqlParam = null)
        {
            using (var connection = Service.GetOpenConnection())
            {
                int res = connection.Execute(sql, sqlParam);
                return res;
            }
        }

    }
}