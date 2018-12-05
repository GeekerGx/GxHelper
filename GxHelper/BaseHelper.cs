using System;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.IO;
using System.ComponentModel;

namespace GxHelper
{
    /// <summary>
    /// 基础工具
    /// v_0.0.4
    /// </summary>
    public static class BaseHelper
    {

        #region 域

        #endregion

        #region 公共方法
        /// <summary>
        /// 对象转成Json字符串
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            string json = null;
            if (obj.GetType() != typeof(string))
            {
                json = JsonConvert.SerializeObject(obj);
            }
            else
            {
                json = obj.ToString();
            }
            return json;
        }

        /// <summary>
        /// Json字符串转成对象
        /// </summary>
        /// <typeparam name="T">待转类型</typeparam>
        /// <param name="json">Json字符串</param>
        /// <returns></returns>
        public static T JsonToObj<T>(this string json)
        {
            Type type = typeof(T);
            return (T)json.JsonToObj(type);
        }
        public static object JsonToObj(this string json, Type type)
        {
            object obj = null;
            if (!type.IsValueType && type != typeof(string))
            {
                obj = JsonConvert.DeserializeObject(json, type);
            }
            else
            {
                obj = Convert.ChangeType(json, type);
            }
            return obj;
        }

        /// <summary>
        /// 对象转成XML字符串
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static string ToXml(this object obj)
        {
            //空值直接返回
            if (obj == null)
            {
                return string.Empty;
            }

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            using (StringWriter sw = new StringWriter())
            {
                serializer.Serialize(sw, obj, ns);
                return sw.ToString();
            }
        }

        /// <summary>
        /// XML字符串转成对象
        /// </summary>
        /// <typeparam name="T">待转类型</typeparam>
        /// <param name="xml">Xml字符串</param>
        /// <returns></returns>
        public static T XmlToObj<T>(this string xml)
        {
            using (StringReader sr = new StringReader(xml))
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                return (T)xs.Deserialize(sr);
            }
        }

        /// <summary>
        /// 通过转成Json比较对象的值是否相等
        /// </summary>
        /// <param name="that"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool EqualsForJson(this object that, object obj)
        {
            return that.ToJson() == obj.ToJson();
        }

        /// <summary>
        /// 类型转换
        /// </summary>
        /// <param name="that"></param>
        /// <param name="type">目标类型</param>
        /// <returns></returns>
        public static object ChangeType(this object that, Type convertsionType)
        {
            if (that == null)
            {
                return null;
            }
            if (convertsionType.IsGenericType && convertsionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                NullableConverter nullableConverter = new NullableConverter(convertsionType);
                convertsionType = nullableConverter.UnderlyingType;
            }
            return Convert.ChangeType(that, convertsionType);
        }

        #endregion

        #region 私有方法

        #endregion
    }
}
