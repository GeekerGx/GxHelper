using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GxHelper
{
    public static class StringHelper
    {
        public static string GetGuid()
        {
            return Guid.NewGuid().ToString("N");
        }
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
        public static string Proper(this string str, char split = '_', string join = "")
        {
            str = str.ToLower();
            string[] list = str.Split(split);
            List<string> strList = new List<string>();
            foreach (string item in list)
            {
                strList.Add(item.Substring(0, 1).ToUpper() + item.Substring(1));
            }
            return string.Join(join, strList);
        }
        public static string DivideWord(this string str, string joinStr = "_", bool toUpper = true)
        {
            List<string> list = RegexString(str, @"[A-Z][^A-Z]+|[A-Z]+(?=[A-Z][^A-Z])|[A-Z]+$");

            if (toUpper)
            {
                list = list.Select(x => x.ToUpper()).ToList();
            }

            return string.Join(joinStr, list);
        }

        public static List<string> RegexString(string str, string expression)
        {
            List<string> list = new List<string>();
            var matchs = Regex.Matches(str, expression);
            foreach (Match match in matchs)
            {
                list.Add(match.Value);
            }
            list.Remove("");
            return list;
        }

        /// <summary>
        /// 进制数据转换成UTF-8
        /// </summary>
        /// <param name="str">需要转换的文本数据</param>
        /// <param name="fromBase">只支持2、8、16进制</param>
        /// <returns>如果不为2、8、16进制则原样返回</returns>
        public static string BitToUTF8(this string str, int fromBase = 2)
        {
            switch (fromBase)
            {
                case 2:
                case 8:
                case 16:
                    break;
                default:
                    return str;
            }
            
            int ratio = (int)(8 / Math.Log(fromBase, 2));
            byte[] b = new byte[str.Length / ratio];
            for (int i = 0; i < str.Length / ratio; i++)
            {
                b[i] = Convert.ToByte(str.Substring(i * ratio, ratio), fromBase);
            }
            return Encoding.UTF8.GetString(b);
        }
    }
}
