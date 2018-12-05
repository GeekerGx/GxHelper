using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class MethodInfoTest
    {
        [TestMethod]
        public void TestVoid()
        {
            MethodInfo method = this.GetType().GetMethod("OnEvent_Click_All", BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            method.Invoke(this, null);
        }
        static void OnEvent_Click_All()
        {
            Console.WriteLine("OK");
        }
        static void OnEvent_Click_Year(string year)
        {
            Console.WriteLine(year);
        }
        [TestMethod]
        public void TestString()
        {
            MethodInfo method = this.GetType().GetMethod("OnEvent_Click_Year", BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            method.Invoke(this,new[] { "aa" });
        }
    }
}
