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
    public class stringFormatTest
    {
        [TestMethod]
        public void TestVoid()
        {
            string aa = string.Format("{0,10:C2}", 999.99);
            string bb = "   ¥999.99";
            Assert.AreEqual(aa, bb);
        }
    }
}
