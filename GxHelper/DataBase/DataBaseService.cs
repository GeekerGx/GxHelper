using System;
using System.Data;
using System.Reflection;

namespace GxHelper.DataBase
{
    /// <summary>
    /// 数据库操作基础类
    /// v0.1.0
    /// </summary>
    internal class DataBaseService
    {
        private DataBaseService(IDataBaseDao dao = null)
        {
            _Dao = dao;
        }
        public static DataBaseService GetService(IDataBaseDao dao = null)
        {
            return new DataBaseService(dao);
        }

        private IDataBaseDao _Dao = null;

        private IDataBaseDao Dao
        {
            get
            {
                if (_Dao == null)
                {
                    //反射对应类
                    Type type = Type.GetType("GxHelper.DataBase." + ConfigHelper.DbType + "Dao");
                    //实例化对象
                    _Dao = (IDataBaseDao)Activator.CreateInstance(type, true);
                }
                return _Dao;
            }
        }

        #region 私有方法

        internal IDbConnection GetOpenConnection()
        {
            try
            {
                IDbConnection connection = Dao.CreateConnection(ConfigHelper.strConn);
                connection.Open();
                return connection;
            }
            catch (Exception e)
            {
                throw new Exception("数据库访问失败。错误提示：" + e.Message);
            }
        }
        internal IDbCommand GetCommand()
        {
            try
            {
                IDbCommand command = Dao.CreateCommand();
                return command;
            }
            catch (Exception e)
            {
                throw new Exception("数据库访问失败。错误提示：" + e.Message);
            }
        }

        internal DataSet ExcuteQuery(string sql)
        {
            using (IDbConnection conn = GetOpenConnection())
            {
                using (IDbCommand comm = GetCommand())
                {
                    comm.CommandText = sql;
                    comm.Connection = conn;
                    IDbDataAdapter da = Dao.CreateDataAdapter();
                    da.SelectCommand = comm;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        #endregion
    }
}
