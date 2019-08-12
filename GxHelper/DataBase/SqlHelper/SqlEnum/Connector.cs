using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GxHelper.AttributeBase;

namespace GxHelper.DataBase.SqlHelper.SqlEnum
{
    /// <summary>
    /// 连接符
    /// </summary>
    enum Connector
    {
        [Enum(" AND")]
        And,
        [Enum(" OR")]
        Or
    }

}
