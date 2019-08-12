using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GxHelper.AttributeBase
{
    public static class AttributeHelper
    {
        /// <summary>
        /// 获取枚举标签属性对象
        /// </summary>
        /// <typeparam name="T">自定义标签</typeparam>
        /// <param name="enumItem">枚举值</param>
        /// <returns></returns>
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
