using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GxHelper.AttributeBase
{
    public class FieldAttribute : Attribute
    {
        public string Field { get; set; }
        public string Name { get; set; }
        public FieldAttribute(string field, string name)
        {
            this.Field = field;
            this.Name = name;
        }
    }
}
