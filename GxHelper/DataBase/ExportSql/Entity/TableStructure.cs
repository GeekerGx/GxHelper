using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GxHelper.DataBase.ExportSql.Entity
{
    /// <summary>
    /// 表结构
    /// </summary>
    class TableStructure
    {
        public string COLUMN_NAME { get; set; }
        public string DATA_TYPE { get; set; }
        public string IS_NULL { get; set; }
        public string IS_KEY { get; set; }
    }
}
