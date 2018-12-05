using GxHelper.AttributeBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GxHelper.DataBase.SqlHelper
{
    public class Join
    {
        public JoinEnum _JoinEnum { get; set; }
        public string _TableName { get; set; }
        public SqlHelper _SqlHelper { get; set; }
        public Join(SqlHelper sqlHelper)
        {
            this._SqlHelper = sqlHelper;
            this._Condition = new Condition(_SqlHelper,this)
            {
                _ConditionBase = new ConditionSingle("1", Comparison.Equal,"1")
            };
        }
        public Condition _Condition { get; set; }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            //join形式，表名
            str.AppendFormat(" {0} {1}",
               EnumHelper.GetEnumContent(_JoinEnum),
                _TableName);
            //条件
            str.AppendFormat(" ON {0}", _Condition.ToString());
            return str.ToString();
        }
    }
}
