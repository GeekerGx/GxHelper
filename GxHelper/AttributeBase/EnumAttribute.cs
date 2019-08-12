using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GxHelper.AttributeBase
{
    /// <summary>
    /// 枚举类型标签属性
    /// </summary>
    public class EnumAttribute: Attribute
    {
        public string Content { get; set; }
        public EnumAttribute(string content)
        {
            this.Content = content;
        }
    }
}
