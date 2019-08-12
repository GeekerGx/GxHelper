using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GxHelper.DataBase.ExportSql
{
    /// <summary>
    /// 导出帮助类
    /// </summary>
    public static class ExportHelper
    {
        private static ExportSqlService _Service = null;
        private static ExportSqlService Service
        {
            get
            {
                if (_Service == null)
                {
                    _Service = ExportSqlService.GetService();
                }
                return _Service;
            }
        }


        /// <summary>
        /// 导出插入语句
        /// </summary>
        /// <param name="tableName">表名称</param>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public static string ExportInsertSql(string tableName, string where)
        {
            tableName = tableName.ToUpper();
            StringBuilder sb = new StringBuilder();

            //获取表结构
            var dataStructureList = Service.GetTableStructure(tableName);

            //获取要导出的数据
            var dt = Service.GetExportData(tableName, where);

            //遍历成插入语句
            foreach (DataRow dr in dt.Rows)
            {
                #region 判断条件
                var key = string.Join(" AND ",
                    dataStructureList
                    .Where(x => !string.IsNullOrEmpty(x.IS_KEY))
                    .Select(x => string.Format(" {0} = '{1}' ", x.COLUMN_NAME, dr[x.COLUMN_NAME])));

                var selectSql = string.Format("SELECT COUNT(*) INTO TOTAL_COUNT FROM {0} WHERE 1=1 AND {1};"
                    , tableName, key);
                #endregion

                #region 插入语句
                var insertSql = string.Format("IF TOTAL_COUNT=0 THEN INSERT INTO " + tableName + " ({0}) VALUES ('{1}'); END IF;"
                    , string.Join(",", dataStructureList.Select(x => x.COLUMN_NAME))
                    , string.Join("','", dataStructureList.Select(x => dr[x.COLUMN_NAME])));
                #endregion

                sb.AppendLine("");
                sb.AppendLine(selectSql + "\n" + insertSql);
            }

            return sb.ToString();
        }
    }
}
