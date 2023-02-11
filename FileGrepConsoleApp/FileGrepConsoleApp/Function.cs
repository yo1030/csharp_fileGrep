using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileGrepConsoleApp
{
    internal class Function
    {
        internal string[] getSampleDirectory(string path)
        {
            string[] directories = Directory.GetDirectories(path, "*_samples");
            while (directories.Length == 0)
            {
                DirectoryInfo? parentDirInfo = Directory.GetParent(path);
                if (parentDirInfo == null)
                {
                    directories[0] = "Error:can't find sample directory";
                }
                else
                {
                    path = parentDirInfo.FullName;
                    directories = Directory.GetDirectories(path, "*_samples");
                }
            }
            return directories;
        }
    }
}
