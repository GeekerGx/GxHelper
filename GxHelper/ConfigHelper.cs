using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace GxHelper
{
    /// <summary>
    /// 获取配置信息
    /// v_0.0.2
    /// </summary>
    public class ConfigHelper
    {
        public static string DbType
        {
            get
            {
                var str = AppSettings("DbType");
                if (str.IsNullOrEmpty())
                {
                    throw new Exception("请添加配置[DbType]");
                }
                return str;
            }
        }
        public static string strConn
        {
            get
            {
                var str = AppSettings("strConn");
                if (str.IsNullOrEmpty())
                {
                    throw new Exception("请添加配置[strConn]");
                }
                return str;
            }
        }
        public static string cookie
        {
            get
            {
                var str = AppSettings("cookie");
                if (str.IsNullOrEmpty())
                {
                    throw new Exception("请添加配置[cookie]");
                }
                return str;
            }
        }


        #region 域

        #endregion

        #region 公共方法
        /// <summary>
        /// 从web.config中读取相应AppSettings的值
        /// </summary>
        /// <param name="name">键值</param>
        /// <returns></returns>
        public static string AppSettings(string name)
        {
            return WebConfigurationManager.AppSettings[name];
        }
        public static string ConnectionStrings(string name)
        {
            return WebConfigurationManager.ConnectionStrings[name].ToString();
        }
        #endregion

        #region 私有方法

        #endregion
    }
}
