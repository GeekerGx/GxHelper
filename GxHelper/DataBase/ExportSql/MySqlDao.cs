using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GxHelper.DataBase.ExportSql.Entity;

namespace GxHelper.DataBase.ExportSql
{
    class MySqlDao : IExportSqlDao
    {
        public List<TableStructure> GetTableStructure(string tableName)
        {
            return DapperHelper.Query<TableStructure>(
                "SELECT "
                + "COLUMN_NAME, DATA_TYPE, IS_NULLABLE IS_NULL, COLUMN_KEY IS_KEY "
                + "FROM  INFORMATION_SCHEMA.COLUMNS "
                + "WHERE TABLE_SCHEMA = DATABASE() "
                + "AND TABLE_NAME = '" + tableName + "'; ").ToList();
        }
    }
}
