// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

string curDir = Environment.CurrentDirectory;
string[] sampleDir = getSampleDirectory(curDir);
for (int i = 0;i < sampleDir.Length; i++)
{
    Console.WriteLine(sampleDir[i]);
}
string[] getSampleDirectory(string path)
{
    string[] directories = Directory.GetDirectories(path, "*_samples");
    while(directories.Length == 0)
    {
        DirectoryInfo? parentDirInfo = Directory.GetParent(path);
        if (parentDirInfo == null)
        {
            directories[0] = "Error:can't find sample directory";
        } else
        {
            path = parentDirInfo.FullName;
            directories = Directory.GetDirectories(path, "*_samples");
        }
    }
    return directories;
}