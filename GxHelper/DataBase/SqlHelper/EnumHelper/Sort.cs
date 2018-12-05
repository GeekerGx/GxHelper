using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GxHelper.AttributeBase;

namespace GxHelper.DataBase.SqlHelper
{
    /// <summary>
    /// 排序符
    /// </summary>
    public enum Sort
    {
        [Enum(" ASC")]
        Asc,
        [Enum(" DESC")]
        Desc
    }
}
