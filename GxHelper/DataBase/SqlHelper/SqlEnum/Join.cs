using GxHelper.AttributeBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GxHelper.DataBase.SqlHelper.SqlEnum
{
    enum JoinEnum
    {
        [Enum(" LEFT JOIN")]
        LeftJoin,
        [Enum(" RIGHT JOIN")]
        RightJoin,
        [Enum(" FULL JOIN")]
        FullJoin
    }
}
