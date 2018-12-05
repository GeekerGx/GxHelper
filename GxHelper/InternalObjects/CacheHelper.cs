using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;

namespace GxHelper.InternalObjects
{
    /// <summary>
    /// Cache-有待维护
    /// v_0.0.0
    /// 2017年10月30日16:18:52
    /// </summary>
    public class CacheHelper
    {
        #region 域
        Cache cache = null;
        #endregion

        #region 公共方法
        public static void Set(string key,object value)
        {
        }
        #endregion

        #region 私有方法
        void NotNull()
        {
            if(cache==null)
            {
                cache = new Cache();
            }
        }
        #endregion
    }
}
