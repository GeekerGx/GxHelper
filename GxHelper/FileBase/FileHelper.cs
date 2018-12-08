using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace GxHelper.FileBase
{
    /// <summary>
    /// 有待维护
    /// </summary>
    public class FileHelper : FileBaes
    {
        #region 域

        private Encoding encoding = Encoding.UTF8;

        private FileStream file { get; set; }
        #endregion

        #region 公共方法
        public FileHelper(string path, string fileName) : base(path, fileName)
        {
            file = new FileStream(path + fileName, FileMode.Append);
        }
        public FileHelper(string path, string fileName, Encoding encoding) : base(path, fileName)
        {
            this.encoding = encoding;
            file = new FileStream(path + fileName, FileMode.OpenOrCreate);
        }

        /// <summary>
        /// 读取内容
        /// </summary>
        /// <returns>返回整个文件内容</returns>
        public string ReadContent()
        {
            StringBuilder read = new StringBuilder();
            foreach (string item in ReadLines())
            {
                read.AppendLine(item);
            }
            return read.ToString();
        }

        /// <summary>
        /// 读取行
        /// </summary>
        /// <returns>返回所有行集合</returns>
        private List<string> ReadLines()
        {
            List<string> lineList = new List<string>();
            StreamReader fileReader = new StreamReader(file, encoding);
            string f;
            while ((f = fileReader.ReadLine()) != null)
            {
                lineList.Add(f);
            }
            return lineList;
        }

        /// <summary>
        /// 向文件追加内容
        /// </summary>
        /// <param name="content">写入内容</param>
        /// <param name="filemode">输入方式</param>
        public void Write(string content)
        {
            using (var write = new StreamWriter(file, encoding))
            {
                write.WriteLine(content);// 直接追加文件末尾，换行   
                write.Flush();
                write.Close();
                write.Dispose();
            }
        }


        /// <summary>
        /// 删除文件
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            return false;
        }

        #endregion

        #region 私有方法
        
        #endregion
    }
}