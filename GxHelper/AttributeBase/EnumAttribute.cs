using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GxHelper.AttributeBase
{
    public class EnumAttribute: Attribute
    {
        public string Content { get; set; }
        public EnumAttribute(string content)
        {
            this.Content = content;
        }
    }
}
