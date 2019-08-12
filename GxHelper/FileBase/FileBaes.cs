using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GxHelper.FileBase
{
    /// <summary>
    /// 有待维护
    /// </summary>
    public abstract class FileBaes
    {

        #region 域
        /// <summary>
        /// 文件夹路径
        /// </summary>
        protected string path;

        /// <summary>
        /// 文件名称
        /// </summary>
        protected string fileName;

        /// <summary>
        /// 获取应用根地址
        /// </summary>
        public static string ServerPath
        {
            get { return AppDomain.CurrentDomain.BaseDirectory; }
        }

        /// <summary>
        /// 获取日志根地址
        /// </summary>
        public static string LogPath
        {
            get { return ServerPath + @"Log\"; }
        }

        /// <summary>
        /// 获取上传根地址
        /// </summary>
        public static string UploadPath
        {
            get { return ServerPath + @"Upload\"; }
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">文件夹路径</param>
        /// <param name="fileName">文件名称</param>
        protected FileBaes(string path, string fileName = "")
        {
            this.path = path;
            this.fileName = fileName;
            DirectoryHelper.Create(path);
        }

        #endregion

        #region 私有方法
        #endregion


    }
}
