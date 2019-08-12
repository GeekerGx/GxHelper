using GxHelper.AttributeBase;
using GxHelper.DataBase.SqlHelper.SqlEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GxHelper.DataBase.SqlHelper
{
    class OrderBy
    {
        public string fieldName { get; set; }
        public Sort sort { get; set; }
        public override string ToString()
        {
            return string.Format(" {0} {1}", 
                fieldName,
               EnumHelper.GetEnumContent(sort) 
                );
        }
    }
}
