using GxHelper.FileBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GxHelper.AttributeBase;

namespace GxHelper.DataBase.SqlHelper
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
}
