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
    public class DirectoryHelper : FileBaes
    {
        #region 域

        #endregion

        #region 公共方法

        /// <summary>
        /// 路径无文件夹则创建
        /// </summary>
        /// <returns></returns>
        public static void Create(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        /// <summary>
        /// 删除目录下所有文件
        /// </summary>
        /// <param name="flag">是否保留该目录</param>
        /// <returns></returns>
        public bool Delete(bool flag)
        {
            if (!Directory.Exists(path))
            {
                return false;
            }
            Directory.Delete(path, true);
            Create(path);
            return true;
        }

        #endregion

        #region 私有方法
        DirectoryHelper(string path) : base(path)
        {

        }
        #endregion
    }
}
