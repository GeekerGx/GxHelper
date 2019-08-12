using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GxHelper.AttributeBase;

namespace GxHelper.DataBase.SqlHelper.SqlEnum
{
    /// <summary>
    /// 排序符
    /// </summary>
    enum Sort
    {
        [Enum(" ASC")]
        Asc,
        [Enum(" DESC")]
        Desc
    }
}
