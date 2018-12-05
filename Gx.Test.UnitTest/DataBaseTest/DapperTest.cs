using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GxHelper.DataBase;

namespace Gx.Test.UnitTest.DataBaseTest
{
    /// <summary>
    /// DapperTest 的摘要说明
    /// </summary>
    [TestClass]
    public class DapperTest
    {
        /// <summary>
        /// 删除
        /// </summary>
        [TestMethod]
        public void DeleteTest()
        {
            string sql = SQLHelper.SetTable("people")
                .ToDeleteSQL();
            DapperHelper.GetService().Execute(sql);
        }
        /// <summary>
        /// 添加
        /// </summary>
        [TestMethod]
        public void InsertTest()
        {
            string sql = SQLHelper.SetTable("people")
                .SetFields("name")
                .ToInsertSQL();
            var param = new[] {
                    new { name = "哈哈哈1" },
                    new { name = "哈哈哈2" },
                    new { name = "哈哈哈3" },
                    new { name = "哈哈哈4" },
                    new { name = "哈哈哈5" } };
            DapperHelper.GetService().Execute(sql, param);
        }
        /// <summary>
        /// 修改
        /// </summary>
        [TestMethod]
        public void UpdateTest()
        {
            string sql = SQLHelper.SetTable("people")
                .SetFields("name")
                .AddCondition("name",SQLHelper.Comparison.Like)
                .AddOrCondition("name", SQLHelper.Comparison.Like, "2")
                .AddOrCondition("name", SQLHelper.Comparison.Between)
                .AddOrCondition("name",SQLHelper.Comparison.Between,"2012")
                .AddOrCondition("name", SQLHelper.Comparison.Between, "2012","2013")
                .ToUpdateSQL();
            DapperHelper.GetService().Execute(sql, new { name = "哈1" });
        }
        /// <summary>
        /// 修改
        /// </summary>
        [TestMethod]
        public void SelectTest()
        {
            string sql = SQLHelper.SetTable("people")
                .SetFields("name")
                .AddCondition("name", SQLHelper.Comparison.Like)
                .ToSelectSQL();
            var list= DapperHelper.GetService().Query<string>(sql,new { name= "%哈%" });
        }
    }
}
