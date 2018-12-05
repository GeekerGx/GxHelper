using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GxHelper;
using System.Xml.Serialization;
using System.Data;
using System.Collections.Generic;

namespace Gx.Test.UnitTest
{
    public class people
    {
        [XmlElement(ElementName = "姓名")]
        public string name;
        [XmlElement(ElementName = "年龄")]
        public int age;
        [XmlElement(ElementName = "性别")]
        public string sex;
        [XmlElement(ElementName = "消息")]
        public List<string> message;

    }
    [TestClass]
    public class BaseHelperTest
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public void ObjectAndXML()
        {
            people aa = new people()
            {
                name = "胡汉三",
                age = 12,
                sex = "男",
                message = new List<string> { "1", "2", "3", "4", "5" }
            };
            string str = aa.ToXml();
            people bb = str.XmlToObj<people>();
            Assert.IsTrue(aa.EqualsForJson(bb));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public void DataTable()
        {
            DataTable dt = new DataTable("NewDataTable");
            dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("name"),
                new DataColumn("age"),
                new DataColumn("sex")
            });
            DataRow dr = dt.NewRow();
            dr["name"] = "胡汉三";
            dr["age"] = 123;
            dr["sex"] = "男";
            dt.Rows.Add(dr);
            string str = dt.ToXml();
            string strJson = dt.ToJson();
            DataTable dtJson = strJson.JsonToObj<DataTable>();
            DataTable dt1 = str.XmlToObj<DataTable>();
            Assert.IsTrue(dt.EqualsForJson(dt1));

        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void DataSet()
        {
            DataSet ds = new DataSet("NewDataSet");
            DataTable dt = new DataTable("NewDataTable");
            dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("name"),
                new DataColumn("age"),
                new DataColumn("sex")
            });
            DataRow dr = dt.NewRow();
            dr["name"] = "胡汉三";
            dr["age"] = 123;
            dr["sex"] = "男";
            dt.Rows.Add(dr);
            ds.Tables.Add(dt);

            DataTable dt2 = new DataTable("NewDataTable2");
            dt2.Columns.AddRange(new DataColumn[] {
                new DataColumn("name"),
                new DataColumn("age"),
                new DataColumn("sex")
            });
            DataRow dr2 = dt2.NewRow();
            dr2["name"] = "胡汉三";
            dr2["age"] = 123;
            dr2["sex"] = "男";
            dt2.Rows.Add(dr2);
            ds.Tables.Add(dt2);

            string str = ds.ToXml();
            DataSet ds1 = str.XmlToObj<DataSet>();
            string strJson = ds.ToJson();
            DataSet dsJson = strJson.JsonToObj<DataSet>();
            Assert.IsTrue(ds.EqualsForJson(ds1));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public void DateTimeAndXML()
        {
            DateTime dt = DateTime.Now;
            string str = dt.ToXml();
            DateTime dt1 = str.XmlToObj<DateTime>();
            Assert.AreEqual(dt, dt1);
        }
        [TestMethod]
        public void ListForJson()
        {
            List<string> aa = new List<string>() {
                "123",
                "321"
            };
            Dictionary<string, List<string>> cc = new Dictionary<string, List<string>>();
            cc.Add("aa",aa);
            string strJson = cc.ToJson();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public void ObjEqualsObjForJson()
        {

            DateTime dt = DateTime.Now;
            object aa = new
            {
                ID = 1,
                PRICE = 45,
                REMARK = "123",
                THOME_PRODUCT_ID = 43,
                TIME = dt
            };
            object bb = new
            {
                ID = 1,
                PRICE = 45,
                REMARK = "123",
                THOME_PRODUCT_ID = 43,
                TIME = dt
            };
            Assert.IsTrue(aa.EqualsForJson(bb));
        }

        [TestMethod]
        public void StringToJson()
        {
            string aa = "123gg";
            aa.JsonToObj(typeof(string));
            aa.JsonToObj<string>();
        }
    }
}
