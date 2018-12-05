using GeetestSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GxHelper.InternalObjects;

namespace GxHelper.Verification
{
    /// <summary>
    /// 极验_滑动行为验证码
    /// v_0.0.2
    /// </summary>
    public class GeetestApiHelper
    {
        #region 域

        #endregion

        #region 公共方法
        /// <summary>
        /// 验证码生成
        /// </summary>
        /// <param name="publicKey">验证码ID</param>
        /// <param name="privateKey">验证码KEY</param>
        /// <returns></returns>
        public static string GetCaptcha(string publicKey, string privateKey)
        {
            GeetestLib geetest = new GeetestLib(publicKey, privateKey);
            string gtServerStatus = geetest.preProcess("test").ToString();
            new CookieHelper(GeetestLib.gtServerStatusSessionKey, gtServerStatus);
            return geetest.getResponseStr();
        }
        /// <summary>
        /// 验证是否正确
        /// </summary>
        /// <param name="publicKey">验证码ID</param>
        /// <param name="privateKey">验证码KEY</param>
        /// <param name="Challenge">参数一</param>
        /// <param name="Validate">参数二</param>
        /// <param name="Seccode">参数三</param>
        /// <returns></returns>
        public static bool Submit(string publicKey, string privateKey, string Challenge, string Validate, string Seccode)
        {
            GeetestLib geetest = new GeetestLib(publicKey, privateKey);
            string gt_server_status_code = CookieHelper.Get(GeetestLib.gtServerStatusSessionKey);
            int result = 0;
            if (gt_server_status_code == "1") result = geetest.enhencedValidateRequest(Challenge, Validate, Seccode, "test");
            else result = geetest.failbackValidateRequest(Challenge, Validate, Seccode);
            return result == 1;
        }
        #endregion

        #region 私有方法

        #endregion
    }

}
