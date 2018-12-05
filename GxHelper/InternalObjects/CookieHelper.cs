using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GxHelper.InternalObjects
{
    /// <summary>
    /// Cookie
    /// v_0.0.2
    /// 2017年10月30日15:52:04
    /// </summary>
    public class CookieHelper
    {
        #region 域

        private string key;

        private string value;

        private static string appCookie = ConfigHelper.AppSettings("cookie");
        #endregion

        #region 公共方法

        /// <summary>
        /// 生成Cookie实例
        /// </summary>
        /// <param name="key">键名</param>
        /// <param name="value">值</param>
        /// <param name="hours">保存时效</param>
        public CookieHelper(string key, string value, int hours = 12)
        {
            this.key = key;
            this.value = value;
            Set(hours);
        }

        /// <summary>
        /// 获取对应的Cookie值
        /// </summary>
        /// <param name="key">键名</param>
        /// <returns></returns>
        public static string Get(string key)
        {
            try
            {
                HttpCookie ck = HttpContext.Current.Request.Cookies[appCookie];
                return ck.Values[key];
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 清除Cookie
        /// </summary>
        public static void RemoveAll()
        {
            HttpCookie ck = new HttpCookie(appCookie);
            ck.Expires = DateTime.Now;
            HttpContext.Current.Response.AppendCookie(ck);
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 保存Cookie
        /// </summary>
        /// <param name="hours">存在时间（小时）</param>
        private void Set(int hours)
        {
            HttpCookie ck = HttpContext.Current.Request.Cookies[appCookie];
            if (ck == null)
            {

                ck = new HttpCookie(ConfigHelper.AppSettings("cookie"));
                ck.Values.Add(this.key, this.value);
            }
            else
            {
                ck.Values.Set(this.key, this.value);
            }
            ck.Expires = DateTime.Now.AddHours(hours);
            HttpContext.Current.Response.AppendCookie(ck);
        }

        #endregion
    }
}
