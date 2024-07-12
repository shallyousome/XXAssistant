using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXAssistant.Util
{
    public class FileUtil
    {
        /// <summary>
        /// 清理文件夹
        /// </summary>
        /// <param name="filepath"></param>
        public static void CleanFile(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                foreach (string filePath in Directory.GetFiles(folderPath))
                {
                    File.Delete(filePath);
                }

                foreach (string directoryPath in Directory.GetDirectories(folderPath))
                {
                    CleanFile(directoryPath);
                    Directory.Delete(directoryPath);
                }
            }
        }
    }
}
