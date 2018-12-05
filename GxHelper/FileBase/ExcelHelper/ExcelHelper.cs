using System;
using NPOI.SS;
using NPOI.HSSF;
using NPOI.XSSF;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using NPOI.SS.UserModel;
using System.Data;
using System.Reflection;
using GxHelper.AttributeBase;

namespace GxHelper.FileBase.ExcelHelper
{
    public class ExcelHelper : FileBaes
    {
        private IWorkbook workBook = null;
        private ExcelaUnicode unicode = ExcelaUnicode.XLSX;
        private FileStream file = null;
        public ExcelHelper(string path, string fileName, ExcelaUnicode unicode = ExcelaUnicode.AUTO)
            : base(path, fileName)
        {
            SetWorkbook(unicode);
        }
        private void SetWorkbook(ExcelaUnicode unicode)
        {
            switch (unicode)
            {
                case ExcelaUnicode.XLS:
                    workBook = new HSSFWorkbook();
                    unicode = ExcelaUnicode.XLS;
                    break;
                case ExcelaUnicode.XLSX:
                    workBook = new XSSFWorkbook();
                    unicode = ExcelaUnicode.XLSX;
                    break;
                case ExcelaUnicode.AUTO:
                    if (fileName.ToUpper().IndexOf(".XLSX") > 0)
                    {
                        workBook = new XSSFWorkbook();
                        unicode = ExcelaUnicode.XLSX;
                    }
                    else
                    {
                        workBook = new HSSFWorkbook();
                        unicode = ExcelaUnicode.XLS;
                    }
                    break;
                default:
                    workBook = new XSSFWorkbook();
                    unicode = ExcelaUnicode.XLSX;
                    break;
            }
        }
        public List<T> ReadExcel<T>()
        {
            ISheet sheet = null;
            List<T> list = new List<T>();
            using (file = new FileStream(base.path + @"\" + base.fileName, FileMode.Open, FileAccess.Read))
            {
                switch (unicode)
                {
                    case ExcelaUnicode.XLS:
                        workBook = new HSSFWorkbook(file);
                        break;
                    case ExcelaUnicode.XLSX:
                        workBook = new XSSFWorkbook(file);
                        break;
                }
                sheet = workBook.GetSheetAt(0);
                var titleIndex = ReadExcelTitle(sheet.GetRow(0));
                list = ReadExcelContent<T>(sheet, titleIndex);
            }
            workBook.Close();
            return list;
        }

        /// <summary>
        /// 尚未完成
        /// </summary>
        /// <returns></returns>
        public DataSet ReadExcel()
        {
            ISheet sheet = null;
            DataSet ds = new DataSet();
            using (file = new FileStream(base.path + @"\" + base.fileName, FileMode.Open, FileAccess.Read))
            {
                switch (unicode)
                {
                    case ExcelaUnicode.XLS:
                        workBook = new HSSFWorkbook(file);
                        break;
                    case ExcelaUnicode.XLSX:
                        workBook = new XSSFWorkbook(file);
                        break;
                }
                for (int i = 0; i < workBook.NumberOfSheets; i++)
                {
                    sheet= workBook.GetSheetAt(0);
                    DataTable dt = new DataTable(sheet.SheetName);
                    ds.Tables.Add(dt);
                }
            }
            return null;
        }
        public void WriteExcel<T>(string tableName, IEnumerable<T> list)
        {
            var sheet = workBook.CreateSheet(tableName);
            var excelAttrs = GetExcelAttrs<T>();
            WriteExcelTitle(sheet, excelAttrs);
            WriteExcelContent(sheet, excelAttrs, list);
        }
        private Dictionary<PropertyInfo, ExcelAttribute> GetExcelAttrs<T>()
        {
            Dictionary<PropertyInfo, ExcelAttribute> dic = new Dictionary<PropertyInfo, ExcelAttribute>();
            Type type = typeof(T);
            PropertyInfo[] propertyInfo = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (PropertyInfo item in propertyInfo)
            {
                object[] objAttrs = item.GetCustomAttributes(typeof(ExcelAttribute), true);
                if (objAttrs.Length > 0)
                {
                    ExcelAttribute attr = objAttrs[0] as ExcelAttribute;
                    if (attr != null)
                    {
                        dic.Add(item, attr);
                    }
                }
            }
            return dic;
        }

        private Dictionary<string, int> ReadExcelTitle(IRow titleRow)
        {
            Dictionary<string, int> titleIndex = new Dictionary<string, int>();
            int itemIndex = 0;
            int colCount = titleRow.LastCellNum;
            for (int colNum = 0; colNum < colCount; colNum++)
            {
                ICell cell = titleRow.GetCell(itemIndex);
                if (cell != null)
                {
                    titleIndex.Add(cell.StringCellValue, itemIndex);
                }
                itemIndex++;
            }
            return titleIndex;
        }
        private void WriteExcelTitle(ISheet sheet, Dictionary<PropertyInfo, ExcelAttribute> excelAttrs)
        {
            var rowTitle = sheet.CreateRow(0);
            int cellIndex = 0;
            foreach (var excelAttr in excelAttrs)
            {
                var cell = rowTitle.CreateCell(cellIndex);
                string value = excelAttr.Value.Name ?? excelAttr.Key.Name;
                cell.SetCellValue(excelAttr.Value.Name);
                cellIndex++;
            }
        }

        private List<T> ReadExcelContent<T>(ISheet sheet, Dictionary<string, int> titleIndex)
        {
            List<T> list = new List<T>();
            var excelAttrs = GetExcelAttrs<T>();
            int rowCount = sheet.LastRowNum;
            for (int rowNum = 1; rowNum <= rowCount; rowNum++)
            {
                IRow row = sheet.GetRow(rowNum);
                int itemIndex = 0;
                T t = default(T);
                t = Activator.CreateInstance<T>();
                foreach (var item in excelAttrs)
                {
                    ICell cell = row.GetCell(titleIndex[item.Value.Name]);

                    object value = null;
                    if (cell != null)
                    {
                        cell.SetCellType(CellType.String);
                        value = cell.StringCellValue.ChangeType(item.Key.PropertyType);
                    }
                    item.Key.SetValue(t, value, null);
                    itemIndex++;
                }
                list.Add(t);
            }
            return list;
        }
        private void WriteExcelContent<T>(ISheet sheet, Dictionary<PropertyInfo, ExcelAttribute> excelAttrs, IEnumerable<T> list)
        {
            int rowIndex = 1;
            foreach (T item in list)
            {
                var rowContent = sheet.CreateRow(rowIndex);
                rowIndex++;
                int cellIndex = 0;
                foreach (var excelAttr in excelAttrs)
                {
                    var cell = rowContent.CreateCell(cellIndex);
                    cellIndex++;
                    object value = excelAttr.Key.GetValue(item);
                    cell.SetCellValue(value == null ? "" : value.ToString());
                }
            }
        }
        public void SaveExcel()
        {
            using (file = new FileStream(base.path + @"\" + base.fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                workBook.Write(file);
            }
            workBook.Close();
        }
    }
}