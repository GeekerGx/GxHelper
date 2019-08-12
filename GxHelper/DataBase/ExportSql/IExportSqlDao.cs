using GxHelper.DataBase.ExportSql.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GxHelper.DataBase.ExportSql
{
    interface IExportSqlDao
    {
        List<TableStructure> GetTableStructure(string tableName);
    }
}
