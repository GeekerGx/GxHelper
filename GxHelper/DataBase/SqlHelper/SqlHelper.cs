using GxHelper.DataBase.SqlHelper.SqlEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GxHelper.AttributeBase;

namespace GxHelper.DataBase.SqlHelper
{
    public class SqlHelper
    {
        /// <summary>
        /// 比较符
        /// </summary>
        public enum Comparison
        {
            /// <summary>
            /// 等于号 =
            /// </summary>
            [Enum(" =")]
            Equal,

            /// <summary>
            /// 不等于号 <>
            /// </summary>
            /// 
            [Enum(" !=")]
            NotEqual,

            /// <summary>
            /// 大于号 >
            /// </summary>
            [Enum(" >")]
            GreaterThan,

            /// <summary>
            /// 大于或等于 >=
            /// </summary>
            [Enum(" >=")]
            GreaterOrEqual,

            /// <summary>
            /// 小于 <
            /// </summary>
            [Enum(" <")]
            LessThan,

            /// <summary>
            /// 小于或等于 =
            /// </summary>
            [Enum(" <=")]
            LessOrEqual,

            /// <summary>
            /// 模糊查询 Like
            /// </summary>
            [Enum(" LIKE")]
            Like,

            /// <summary>
            /// is null
            /// </summary>
            [Enum(" IS NULL")]
            IsNull,

            /// <summary>
            /// is not null
            /// </summary>
            [Enum(" IS NOT NULL")]
            IsNotNull,

            /// <summary>
            /// in
            /// </summary>
            [Enum(" IN")]
            In,

            /// <summary>
            /// not in
            /// </summary>
            [Enum(" NOT IN")]
            NotIn,
        }

        private string _tableName = "";
        private List<string> _fields = new List<string>() { "*" };
        private List<Join> _JoinList = new List<Join>();
        internal Condition _Condition { get; set; }
        private List<OrderBy> _OrderByList = new List<OrderBy>();
        /// <summary>
        /// 创建SQLHelper对象
        /// </summary>
        /// <param name="isAllowEmpty">是否生成IS NULL查询条件</param>
        private SqlHelper(string tableName)
        {
            _tableName = tableName;
            _Condition = new Condition(this, null)
            {
                _ConditionBase = new ConditionSingle("1", Comparison.Equal, "1")
            };
        }
        public static SqlHelper SetTable(string tableName)
        {
            return new SqlHelper(tableName);
        }
        #region 公共
        public SqlHelper SetFields(params string[] fields)
        {
            _fields.Remove("*");
            _fields.AddRange(fields);
            return this;
        }

        public SqlHelper OrderByAsc(string fieldName)
        {
            _OrderByList.Add(new OrderBy
            {
                fieldName = fieldName,
                sort = Sort.Asc
            });
            return this;
        }
        public SqlHelper OrderByDesc(string fieldName)
        {
            _OrderByList.Add(new OrderBy
            {
                fieldName = fieldName,
                sort = Sort.Desc
            });
            return this;
        }

        /// <summary>
        /// 获取查询语句
        /// </summary>
        /// <returns></returns>
        public string ToSelectSQL()
        {
            StringBuilder str = new StringBuilder();
            //select 列名
            str.AppendFormat(" SELECT {0}", string.Join(" ,", _fields));
            //from 表名
            str.AppendFormat(" FROM {0}", _tableName);
            //join
            if (_JoinList.Count > 0)
            {
                _JoinList.ForEach(join =>
                {
                    str.AppendFormat(" {0}", join.ToString());
                });
            }
            //where 条件
            str.AppendFormat(" WHERE {0}", _Condition.ToString());
            //order by 字段
            if (_OrderByList.Count > 0)
            {
                List<string> orderByList = new List<string>();
                _OrderByList.ForEach(orderBy =>
                {
                    orderByList.Add(orderBy.ToString());
                });
                str.AppendFormat(" ORDER BY {0}", string.Join(",", orderByList));
            }
            return str.ToString();
        }

        /// <summary>
        /// 获取修改语句
        /// </summary>
        /// <returns></returns>
        public string ToUpdateSQL()
        {
            var updateVals = new List<string>();
            foreach (string item in _fields)
            {
                updateVals.Add(string.Format("{0} = @{0}", item));
            }
            return string.Format("UPDATE {0} SET {1} {2}",
                _tableName,
                string.Join(" , ", updateVals),
                _Condition.ToString());
        }

        /// <summary>
        /// 获取新增语句
        /// </summary>
        /// <returns></returns>
        public string ToInsertSQL()
        {
            var fields = new List<string>();
            var vals = new List<string>();
            foreach (string item in _fields)
            {
                fields.Add(item.ToString());
                vals.Add(string.Format("@{0}", item.ToString()));
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
                _Condition.ToString());
        }
        public Condition AddJoin(string tableName)
        {
            var join = new Join(this)
            {
                _JoinEnum = JoinEnum.LeftJoin,
                _TableName = tableName
            };
            _JoinList.Add(join);
            return join._Condition;
        }
        public Condition AddWhere()
        {
            return this._Condition;
        }
        #endregion 公共
    }
}
