using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GxHelper
{
    /// <summary>
    /// 数据加密
    /// v_0.0.1
    /// </summary>
    public class DataCryptHelper
    {
        #region 域

        #endregion

        #region 公共方法

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str">待加密字符串</param>
        /// <returns></returns>
        public static string MD5(string str)
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            return ASCIIEncoding.ASCII.GetString(md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(str)));
        }

        #endregion

        #region 私有方法

        #endregion
    }
}
