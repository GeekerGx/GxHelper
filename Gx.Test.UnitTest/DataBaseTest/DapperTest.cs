using Microsoft.VisualStudio.TestTools.UnitTesting;
using GxHelper.DataBase;
using GxHelper.DataBase.SqlHelper;
using GxHelper.DataBase.SqlHelper.SqlEnum;

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
            string sql = SqlHelper.SetTable("people")
                .ToDeleteSQL();
            DapperHelper.Execute(sql);
        }
        /// <summary>
        /// 添加
        /// </summary>
        [TestMethod]
        public void InsertTest()
        {
            string sql = SqlHelper.SetTable("people")
                .SetFields("name")
                .ToInsertSQL();
            var param = new[] {
                    new { name = "哈哈哈1" },
                    new { name = "哈哈哈2" },
                    new { name = "哈哈哈3" },
                    new { name = "哈哈哈4" },
                    new { name = "哈哈哈5" } };
            DapperHelper.Execute(sql, param);
        }
        /// <summary>
        /// 修改
        /// </summary>
        [TestMethod]
        public void UpdateTest()
        {
            string sql = SqlHelper.SetTable("people")
                .SetFields("name")
                .AddWhere()
                .AddAndCondition("name", SqlHelper.Comparison.Like)
                .AddOrCondition("name", SqlHelper.Comparison.Like, "2")
                .EndWhere()
                .ToUpdateSQL();
            DapperHelper.Execute(sql, new { name = "哈1" });
        }
        /// <summary>
        /// 修改
        /// </summary>
        [TestMethod]
        public void SelectTest()
        {
            string sql = SqlHelper.SetTable("people")
                .SetFields("name")
                .AddWhere()
                .AddAndCondition("name", SqlHelper.Comparison.Like)
                .EndWhere()
                .ToSelectSQL();
            var list = DapperHelper.Query<string>(sql, new { name = "%哈%" });
        }
    }
}
