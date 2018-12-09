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
using GxHelper.FileBase.LogHelper;

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
            LogHelper.Debug("123321");
        }
        
    }
}
