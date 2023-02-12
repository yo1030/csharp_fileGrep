// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Text;
using FileGrepConsoleApp;

string curDir = Environment.CurrentDirectory;
Function fc = new Function();

List<string> sampleDir = fc.getSampleDirectory(curDir);
if (sampleDir[0].IndexOf("error", StringComparison.CurrentCultureIgnoreCase) != -1)
{
    Console.WriteLine(sampleDir[0]);
    return;
}
fc.createResult(sampleDir);
