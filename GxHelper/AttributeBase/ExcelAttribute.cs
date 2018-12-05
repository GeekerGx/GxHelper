using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GxHelper.AttributeBase
{
    public class ExcelAttribute:Attribute
    {
        public string Name { get; set; }
        public ExcelAttribute(string name)
        {
            this.Name = name;
        }
    }
}
