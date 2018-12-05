using GxHelper.AttributeBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GxHelper.DataBase.SqlHelper
{
    public static class EnumHelper
    {
        public static string GetEnumContent(Enum item)
        {
            return item.GetEnumAttribute<EnumAttribute>().Content;
        }
    }
}
