using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
