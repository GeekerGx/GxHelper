using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GxHelper.AttributeBase
{
    public static class AttributeHelper
    {
        public static T GetEnumAttribute<T>(this object enumItem) where T : Attribute
        {
            Type type = enumItem.GetType();
            var fieldName = System.Enum.GetName(type, enumItem);
            var objAttrs = type.GetField(fieldName).GetCustomAttributes(false);
            var enumAttribute = (T)objAttrs.FirstOrDefault(x => x.GetType().Equals(typeof(T)));
            return enumAttribute;
        }
    }
}
