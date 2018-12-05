using Quartz;
using Quartz.Impl;
using System;
using System.Threading;
using GxHelper.FileBase;
using GxHelper;
using GxHelper.DataBase.SqlHelper;
using GxHelper.TaskSchedul;
using System.Collections.Generic;
using System.Diagnostics;
using GxHelper.AttributeBase;
using System.Linq;
using System.Text;

namespace Gx.Test.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Test();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
        static void Test()
        {
            StringBuilder content = new StringBuilder();
            content.AppendFormat("Time：{0,20}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            content.AppendLine();
            content.AppendFormat("用户组：{0,18}", "Gx");
            content.AppendLine();
            content.AppendFormat("累计：{0,18:C2}￥", 299.936);
            content.AppendLine();
            Console.WriteLine(content.ToString());
        }
        
    }
}
