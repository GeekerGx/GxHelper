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
