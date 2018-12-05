using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GxHelper.AttributeBase;

namespace GxHelper.DataBase.SqlHelper
{
    /// <summary>
    /// 条件基础——单个
    /// </summary>
    public class ConditionSingle
    {
        public ConditionSingle(string fieldName, Comparison comparison, string param, bool isValue = true)
        {
            this._FieldName = fieldName;
            this._Comparison = comparison;
            this._Param = param;
            if (_Param == null)
            {
                _Param = "@" + fieldName.Split('.').LastOrDefault();
                isValue = false;
            }
            if (comparison == Comparison.IsNull)
            {
                _Param = "";
                isValue = false;
            }
            this._isValue = isValue;
        }
        bool _isValue { get; set; }
        string _FieldName { get; set; }
        Comparison _Comparison { get; set; }
        string _Param { get; set; }
        public override string ToString()
        {
            return string.Format(" ({0} {1} {2})",
                _FieldName,
                EnumHelper.GetEnumContent(_Comparison),
                _isValue ? "'" + _Param + "'" : _Param
                );
        }
    }
}
