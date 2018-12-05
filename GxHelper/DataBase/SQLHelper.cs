using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GxHelper.DataBase
{
    /// <summary>
    /// 被遗弃的
    /// </summary>
    public class SQLHelper
    {
        #region public enum Comparison

        /// <summary>
        /// 比较符
        /// </summary>
        public enum Comparison
        {
            /// <summary>
            /// 等于号 =
            /// </summary>
            Equal,

            /// <summary>
            /// 不等于号 <>
            /// </summary>
            NotEqual,
            /// <summary>
            /// 比较或参数为空
            /// </summary>
            EqualOrNull,

            /// <summary>
            /// 大于号 >
            /// </summary>
            GreaterThan,

            /// <summary>
            /// 大于或等于 >=
            /// </summary>
            GreaterOrEqual,

            /// <summary>
            /// 小于 &lt;
            /// </summary>
            LessThan,

            /// <summary>
            /// 小于或等于 =
            /// </summary>
            LessOrEqual,

            /// <summary>
            /// 模糊查询 Like
            /// </summary>
            Like,

            /// <summary>
            /// 模糊查询  Not Like
            /// </summary>
            NotLike,

            /// <summary>
            /// is null
            /// </summary>
            IsNull,

            /// <summary>
            /// is not null
            /// </summary>
            IsNotNull,

            /// <summary>
            /// in
            /// </summary>
            In,

            /// <summary>
            /// not in
            /// </summary>
            NotIn,

            /// <summary>
            /// 左括号 （
            /// </summary>
            OpenParenthese,

            /// <summary>
            /// 右括号 )
            /// </summary>
            CloseParenthese,

            Between,
            StartsLike,
            EndsLike,

            /// <summary>
            /// 是否包含字符
            /// </summary>
            InStr
        }

        /// <summary>
        /// 排序符
        /// </summary>
        public enum Sort
        {
            ASC,
            DESC
        }

        private class Join
        {
            string TableName { get; set; }
            string On { get; set; }
            List<Condition> conList { get; set; }
        }
        private class Condition
        {
            string connector { get; set; }
            string Field1 { get; set; }
            Comparison Com { get; set; }
            string Field2 { get; set; }
        }
        #endregion public enum Comparison

        #region 变量定义

        private string _tableName = "";

        /// <summary>
        /// 创建SQLHelper对象
        /// </summary>
        /// <param name="isAllowEmpty">是否生成IS NULL查询条件</param>
        private SQLHelper(string tableName)
        {
            _tableName = tableName;
        }
        public static SQLHelper SetTable(string tableName)
        {
            return new SQLHelper(tableName);
        }
        private List<string> _fields = new List<string>() { "*" };
        public SQLHelper SetFields(params string[] fields)
        {
            _fields.Remove("*");
            _fields.AddRange(fields);
            return this;
        }

        /// <summary>
        /// JOIN语句
        /// </summary>
        private StringBuilder join = new StringBuilder();

        /// <summary>
        /// 条件语句
        /// </summary>
        private StringBuilder condition = new StringBuilder();

        /// <summary>
        /// 排序语句
        /// </summary>
        private StringBuilder orderby = new StringBuilder();

        private const string and = " AND ";
        private const string or = " OR ";

        #endregion 变量定义

        #region 构造函数


        #endregion 构造函数

        #region 公共
        /// <summary>
        /// 获取查询语句
        /// </summary>
        /// <returns></returns>
        public string ToSelectSQL()
        {
            return string.Format("SELECT {0} FROM {1} {2} {3}", 
                string.Join(", ", _fields), 
                _tableName, 
                GetCondition(), 
                GetOrderBy());
        }

        /// <summary>
        /// 获取修改语句
        /// </summary>
        /// <returns></returns>
        public string ToUpdateSQL()
        {
            var updateVals = new List<string>();
            foreach(string item in _fields)
            {
                updateVals.Add(string.Format("{0} = @{0}", item));
            }
            return string.Format("UPDATE {0} SET {1} {2}", 
                _tableName, 
                string.Join(" , ", updateVals), 
                GetCondition());
        }

        /// <summary>
        /// 获取新增语句
        /// </summary>
        /// <returns></returns>
        public string ToInsertSQL()
        {
            var fields = new List<string>();
            var vals = new List<string>();
            foreach(string item in _fields)
            {
                fields.Add(item.ToString());
                vals.Add(string.Format("@{0}",item.ToString()));
            }
            return string.Format("INSERT INTO {0} ({1}) VALUES ({2}) ", 
                _tableName, 
                string.Join(", ", fields), 
                string.Join(", ", vals));
        }

        /// <summary>
        /// 获取删除语句
        /// </summary>
        /// <returns></returns>
        public string ToDeleteSQL()
        {
            return string.Format("DELETE FROM {0} {1}", 
                _tableName, 
                GetCondition());
        }

        /// <summary>
        /// 获取条件
        /// </summary>
        /// <returns></returns>
        private string GetCondition()
        {
            var cond = condition.ToString();
            if (string.IsNullOrEmpty(cond))
            {
                return "";
            }
            else
            {
                return string.Format(" WHERE {0} ", cond);
            }
        }

        /// <summary>
        /// 获取排序
        /// </summary>
        /// <returns></returns>
        private string GetOrderBy()
        {
            var ob = orderby.ToString();
            if (string.IsNullOrEmpty(ob))
            {
                return "";
            }
            else
            {
                return string.Format(" ORDER BY {0} ", ob);
            }
        }

        #endregion 公共
        
        /// <summary>
        /// 左连接
        /// </summary>
        /// <param name="table">表名称</param>
        /// <param name="fieldvals">字段及值</param>
        /// <returns>返回SQLHelper</returns>
        public SQLHelper LeftJoin(string table, params object[] fieldvals)
        {
            var on = "";
            var onList = new List<string>();
            for (int i = 0; i < fieldvals.Count(); i++)
            {
                if (i % 2 == 0)
                {
                    //如果是字段
                    on += fieldvals[i] + " = ";
                }
                else
                {
                    //如果是值
                    on += string.Format("{0}", fieldvals[i]);

                    //添加到列表
                    onList.Add(on);
                    on = "";
                }
            }

            join.Append(string.Format("LEFT OUTER JOIN {0} ON {1} ", table, string.Join(" AND ", onList)));

            return this;
        }
        
        

        #region 条件

        /// <summary>
        /// 添加and 条件
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="comparison">比较符类型</param>
        /// <param name="fieldValue">字段值</param>
        /// <returns>返回SQLHelper</returns>
        public SQLHelper AddAndCondition(string fieldName, Comparison comparison, params object[] fieldValue)
        {
            condition.Append(and);
            this.AddCondition(fieldName, comparison, fieldValue);
            return this;
        }

        /// <summary>
        /// 添加or条件
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="comparison">比较符类型</param>
        /// <param name="fieldValue">字段值</param>
        /// <returns>返回SQLHelper</returns>
        public SQLHelper AddOrCondition(string fieldName, Comparison comparison, params object[] fieldValue)
        {
            condition.Append(or);
            this.AddCondition(fieldName, comparison, fieldValue);
            return this;
        }

        /// <summary>
        /// 添加and+左括号+条件
        /// </summary>
        /// <param name="comparison">比较符类型</param>
        /// <param name="fieldName">字段名称</param>
        /// <param name="fieldValue">字段值，注：Between时，此字段必须填两个值</param>
        /// <returns>返回SQLHelper</returns>
        public SQLHelper AddAndOpenParenthese(string fieldName, Comparison comparison, params object[] fieldValue)
        {
            this.condition.AppendFormat("{0}{1}", and, GetComparisonOperator(Comparison.OpenParenthese));
            this.AddCondition(fieldName, comparison, fieldValue);
            return this;
        }

        /// <summary>
        /// 添加or+左括号+条件
        /// </summary>
        /// <returns></returns>
        /// <param name="comparison">比较符类型</param>
        /// <param name="fieldName">字段名称</param>
        /// <param name="fieldValue">字段值，注：Between时，此字段必须填两个值</param>
        /// <returns>返回SQLHelper</returns>
        public SQLHelper AddOrOpenParenthese(string fieldName, Comparison comparison, params object[] fieldValue)
        {
            this.condition.AppendFormat("{0}{1}", or, GetComparisonOperator(Comparison.OpenParenthese));
            this.AddCondition(fieldName, comparison, fieldValue);
            return this;
        }

        /// <summary>
        /// 添加右括号
        /// </summary>
        /// <returns></returns>
        public SQLHelper AddCloseParenthese()
        {
            this.condition.Append(GetComparisonOperator(Comparison.CloseParenthese));
            return this;
        }

        /// <summary>
        /// 添加条件
        /// </summary>
        /// <param name="comparison">比较符类型</param>
        /// <param name="fieldName">字段名称</param>
        /// <param name="fieldValue">字段值，注：Between时，此字段必须填两个值</param>
        /// <returns>返回SQLHelper</returns>
        public SQLHelper AddCondition(string fieldName, Comparison comparison, params object[] fieldValue)
        {
            bool isParam = false;
            switch(fieldValue.Length)
            {
                case 0:
                    isParam = true;
                    break;
                case 1:
                    return AddCondition(fieldName, comparison, fieldValue[0], fieldValue[0]);
            }
            switch (comparison)
            {
                case Comparison.Equal:
                case Comparison.NotEqual:
                case Comparison.GreaterThan:
                case Comparison.GreaterOrEqual:
                case Comparison.LessThan:
                case Comparison.LessOrEqual:
                    this.condition.AppendFormat("{0}{1}{2}", GetFieldName(fieldName), GetComparisonOperator(comparison), isParam ? GetParamName(fieldName) : GetFieldValue(fieldValue[0]));
                    break;

                case Comparison.IsNull:
                case Comparison.IsNotNull:
                    this.condition.AppendFormat("{0}{1}", GetFieldName(fieldName), GetComparisonOperator(comparison));
                    break;

                case Comparison.Like:
                case Comparison.NotLike:
                    this.condition.AppendFormat("{0}{1}{2}", GetFieldName(fieldName), GetComparisonOperator(comparison), isParam ? GetParamName(fieldName) : GetFieldValue(string.Format("%{0}%", fieldValue[0])));
                    break;

                case Comparison.In:
                case Comparison.NotIn:
                    this.condition.AppendFormat("{0}{1}({2})", GetFieldName(fieldName), GetComparisonOperator(comparison), string.Join(",", GetFieldValue(fieldValue)));
                    break;

                case Comparison.StartsLike:
                    this.condition.AppendFormat("{0}{1}{2}", GetFieldName(fieldName), GetComparisonOperator(comparison), isParam ? GetParamName(fieldName) : GetFieldValue(string.Format("{0}%", fieldValue[0])));
                    break;

                case Comparison.EndsLike:
                    this.condition.AppendFormat("{0}{1}{2}", GetFieldName(fieldName), GetComparisonOperator(comparison), isParam ? GetParamName(fieldName) : GetFieldValue(string.Format("%{0}", fieldValue[0])));
                    break;

                case Comparison.Between:
                    this.condition.AppendFormat("{0}{1}{2} AND {3}", GetFieldName(fieldName), GetComparisonOperator(comparison), isParam ? GetParamName(fieldName) : GetFieldValue(fieldValue[0]), isParam ? GetParamName(fieldName) : GetFieldValue(fieldValue[1]));
                    break;

                case Comparison.InStr:
                    this.condition.AppendFormat("INSTR(',' || {1} || ',', ',' || {0} || ',' ) > 0", GetFieldName(fieldName), isParam ? GetParamName(fieldName) : GetFieldValue(fieldValue[0]));
                    break;
                case Comparison.EqualOrNull:
                    this.condition.AppendFormat("({0} IS NULL OR {1}{2}{0})", isParam ? GetParamName(fieldName) : GetFieldValue(fieldValue[0]), GetFieldName(fieldName), GetComparisonOperator(comparison));
                    break;
                default:
                    throw new Exception("条件未定义");
            }
            return this;
        }

        #endregion 条件

        #region 排序

        /// <summary>
        /// 添加and 条件
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="comparison">比较符类型</param>
        /// <param name="fieldValue">字段值</param>
        /// <returns>返回SQLHelper</returns>
        public SQLHelper AddOrderBy(string fieldName, Sort sort = Sort.ASC)
        {
            orderby.AppendFormat("{0} {1}", GetFieldName(fieldName), (sort == Sort.DESC ? "DESC" : "ASC"));
            return this;
        }

        #endregion 排序

        #region 私有方法

        /// <summary>
        /// 取得字段值
        /// </summary>
        /// <param name="fieldValue"></param>
        /// <returns></returns>
        private string GetFieldValue(params object[] fieldValue)
        {
            if (fieldValue.Length < 2)
            {
                return string.Format("'{0}'", fieldValue[0]);
            }
            else
            {
                return string.Format("'{0}'", string.Join("','", fieldValue));
            }
        }

        private string GetParamName(string paramName)
        {
            return string.Format("@{0}", paramName);
        }
        private string GetFieldName(string fieldName)
        {
            return string.Format("{0}", fieldName);
        }

        private static string GetComparisonOperator(Comparison comparison)
        {
            string result = string.Empty;
            switch (comparison)
            {
                case Comparison.Equal:
                    result = " = ";
                    break;

                case Comparison.NotEqual:
                    result = " <> ";
                    break;

                case Comparison.GreaterThan:
                    result = " > ";
                    break;

                case Comparison.GreaterOrEqual:
                    result = " >= ";
                    break;

                case Comparison.LessThan:
                    result = " < ";
                    break;

                case Comparison.LessOrEqual:
                    result = " <= ";
                    break;

                case Comparison.Like:
                case Comparison.StartsLike:
                case Comparison.EndsLike:
                    result = " LIKE ";
                    break;

                case Comparison.NotLike:
                    result = " NOT LIKE ";
                    break;

                case Comparison.IsNull:
                    result = " IS NULL ";
                    break;

                case Comparison.IsNotNull:
                    result = " IS NOT NULL ";
                    break;

                case Comparison.In:
                    result = " IN ";
                    break;

                case Comparison.NotIn:
                    result = " NOT IN ";
                    break;

                case Comparison.OpenParenthese:
                    result = " (";
                    break;

                case Comparison.CloseParenthese:
                    result = ") ";
                    break;

                case Comparison.Between:
                    result = " BETWEEN ";
                    break;
            }
            return result;
        }
        #endregion 私有方法
    }
}