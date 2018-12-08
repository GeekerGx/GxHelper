using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GxHelper.InternalObjects
{
    /// <summary>
    /// Session
    /// v_0.0.1
    /// 2017年10月30日15:52:23
    /// </summary>
    public class SessionHelper
    {
        #region 域

        private string key;

        private object value;

        #endregion

        #region 公共方法

        public SessionHelper(string key,object value,int hours=2)
        {
            this.key = key;
            this.value = value;
            Set(hours);
        }

        public static T Get<T>(string key)
        {
            try
            {
                return (T)HttpContext.Current.Session[key];
            }
            catch
            {
                return default(T);
            }
        }
        public static void RemoveKey(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }

        public static void RemoveAll()
        {
            HttpContext.Current.Session.Clear();
        }

        #endregion

        #region 私有方法

        void Set(int hours)
        {
            HttpContext.Current.Session[key] = value;
        }

        #endregion
    }
}
