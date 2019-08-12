using GxHelper.DataBase.ExportSql.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GxHelper.DataBase.ExportSql
{
    class ExportSqlService
    {
        private ExportSqlService(IExportSqlDao dao = null)
        {
            this._Dao = dao;
        }
        public static ExportSqlService GetService(IExportSqlDao dao = null)
        {
            return new ExportSqlService(dao);
        }

        private IExportSqlDao _Dao = null;

        private IExportSqlDao Dao
        {
            get
            {
                if (_Dao == null)
                {
                    //反射对应类
                    Type type = Type.GetType("GxHelper.DataBase.ExportSql." + ConfigHelper.DbType + "Dao");
                    //实例化对象
                    _Dao = (IExportSqlDao)Activator.CreateInstance(type, true);
                }
                return _Dao;
            }
        }

        public List<TableStructure> GetTableStructure(string tableName)
        {
            tableName = tableName.ToUpper();
            return Dao.GetTableStructure(tableName);
        }

        public DataTable GetExportData(string tableName, string where)
        {
            tableName = tableName.ToUpper();
            //获取要导出的数据
            return DapperHelper.QueryDataTable(
                "SELECT * FROM "
                + tableName + " "
                + (string.IsNullOrEmpty(where) ? " " : " WHERE " + where));
        }

    }
}
