using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GxHelper.SMS
{
    /// <summary>
    /// 短信接口
    /// v_0.0.1
    /// </summary>
    interface ISMSBase
    {
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <returns></returns>
        bool DoSMS();
    }
}
