using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileGrepConsoleApp
{
    internal class Function
    {
        internal List<string> getSampleDirectory(string path)
        {
            List<string> directories = Directory.GetDirectories(path.ToLower(), "*_sample*").ToList();
            while (directories.Count == 0)
            {
                DirectoryInfo? parentDirInfo = Directory.GetParent(path);
                if (parentDirInfo == null)
                {
                    directories.Add("Error:can't find sample directory");
                }
                else
                {
                    path = parentDirInfo.FullName;
                    directories = Directory.GetDirectories(path.ToLower(), "*_sample*").ToList();
                }
            }
            return directories;
        }
        internal void createResult(List<string> targetDir)
        {
            bool isHTML = false;
            bool isPHP = false;
            bool isCSHARP = false;
            for (int i = 0;i < targetDir.Count; i++)
            {
                string targetDirName = targetDir[i];
                DirectoryInfo targetDirInfo = new DirectoryInfo(targetDirName);
                string dirName = targetDirInfo.Name.ToLower();
                isHTML = (dirName.IndexOf("htmlcss") != -1);
                isPHP = (dirName.IndexOf("php") != -1);
                isCSHARP = (dirName.IndexOf("csharp") != -1);
                if (isHTML)
                {
                    outputFileList(targetDirName, "html");
                    isHTML = false;
                }
                if (isPHP)
                {
                    outputFileList(targetDirName, "php");
                    isPHP = false;
                }
                if (isCSHARP)
                {
                    outputFileList(targetDirName, "cs");
                    isCSHARP = false;
                }
            }
            void outputFileList(string targetDir, string type)
            {
                string suffixName = "result" + type.ToUpper() + ".txt";
                DirectoryInfo dirInfo = new DirectoryInfo(targetDir);
                DirectoryInfo? parDirInfo = Directory.GetParent(targetDir);
                IEnumerable<string> fileList = dirInfo.EnumerateFiles("*." + type, SearchOption.AllDirectories)
                                                        .Select(f => f.Name);
                if (parDirInfo == null)
                {
                    string? rootDir = Path.GetPathRoot(dirInfo.FullName);
                    File.WriteAllLines(rootDir + @"\" + suffixName, fileList, Encoding.UTF8);
                }
                else
                {
                    DirectoryInfo resultDir = Directory.CreateDirectory(parDirInfo.FullName + @"\result");
                    File.WriteAllLines(resultDir + @"\" + suffixName, fileList, Encoding.UTF8);
                }
            }
        }
    }
}
