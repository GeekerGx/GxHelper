using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GxHelper.FileBase.ExcelHelper
{
    public enum ExcelaUnicode
    {
        /// <summary>
        /// 2007版本前
        /// </summary>
        XLS,
        /// <summary>
        /// 2007版本后
        /// </summary>
        XLSX,
        /// <summary>
        /// 根据文件后缀判断编码格式
        /// </summary>
        AUTO
    }
}
