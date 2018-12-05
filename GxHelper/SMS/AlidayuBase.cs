using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;

namespace GxHelper.SMS
{
    /// <summary>
    /// 阿里大鱼
    /// v_0.0.4
    /// </summary>
    public class AlidayuBase : ISMSBase
    {
        /// <summary>
        /// 基础配置
        /// </summary>
        protected class Client
        {
            #region 域
            /// <summary>
            /// 接口网址
            /// </summary>
            public string url;
            /// <summary>
            /// 接口秘钥
            /// </summary>
            public string appkey;
            /// <summary>
            /// 接口密码
            /// </summary>
            public string secret;
            #endregion

            #region 公共方法

            #endregion

            #region 私有方法

            #endregion
        }
        /// <summary>
        /// 详细配置
        /// </summary>
        protected class Reg
        {
            #region 域
            /// <summary>
            /// 会员ID
            /// </summary>
            public string extend;
            /// <summary>
            /// 短信类型
            /// </summary>
            public string smsType;
            /// <summary>
            /// 短信签名
            /// </summary>
            public string smsFreeSignName;
            /// <summary>
            /// 短信模板变量
            /// </summary>
            public string smsParam;
            /// <summary>
            /// 短信接收号码
            /// </summary>
            public string recNum;
            /// <summary>
            /// 短信模板ID
            /// </summary>
            public string smsTemplateCode;
            #endregion

            #region 公共方法

            #endregion

            #region 私有方法

            #endregion
        }

        #region 域
        protected Client client;
        protected Reg reg;
        #endregion

        #region 公共方法
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <returns></returns>
        public bool DoSMS()
        {
            ITopClient topclient = new DefaultTopClient(client.url, client.appkey, client.secret);
            /*AlibabaAliqinFcSmsNumSendRequest FcSmsNumSendRequest = new AlibabaAliqinFcSmsNumSendRequest() {
                Extend= reg.extend,
                SmsType = reg.smsType,
                SmsFreeSignName = reg.smsFreeSignName,
                SmsParam = reg.smsParam,
                RecNum = reg.recNum,
                SmsTemplateCode = reg.smsTemplateCode
            };
            AlibabaAliqinFcSmsNumSendResponse rsp = topclient.Execute(FcSmsNumSendRequest);*/
            









            
            return true;
        }
        #endregion

        #region 私有方法

        #endregion
    }
}
