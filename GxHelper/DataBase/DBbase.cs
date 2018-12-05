using System;
using System.Data;
using System.Reflection;

namespace GxHelper.DataBase
{
    /// <summary>
    /// 数据库操作基础类
    /// v0.1.0
    /// </summary>
    public class DBbase
    {

        #region 域

        static protected IDBBase DBB=null;

        static string _strConn;

        #endregion

        #region 公共方法

        public DBbase()
        {
            if(DBB==null)
            {
                //数据库链接语句
                _strConn = ConfigHelper.AppSettings("strConn");
                //反射对应类
                Type type = Type.GetType("GxHelper.DataBase." + ConfigHelper.AppSettings("DbType") + "Base");
                //实例化对象
                DBB = (IDBBase)Activator.CreateInstance(type, true);
            }
        }

        #endregion

        #region 私有方法

        protected IDbConnection GetOpenConnection()
        {
            if(DBB == null)
            {
                throw new Exception("数据库类型为空，请添加配置[DbType]。");
            }
            if (_strConn == null)
            {
                throw new Exception("数据库链接语句为空，请添加配置[strConn]。");
            }
            try
            {
                IDbConnection connection = DBB.CreateConnection(_strConn);
                connection.Open();
                return connection;
            }
            catch(Exception e)
            {
                throw new Exception("数据库访问失败。错误提示：" + e.Message);
            }
        }

        #endregion
    }
}
