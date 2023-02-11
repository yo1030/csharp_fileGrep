// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Text;
using FileGrepConsoleApp;

string curDir = Environment.CurrentDirectory;
Function fc = new Function();

string[] sampleDir = fc.getSampleDirectory(curDir);
fc.createResult(sampleDir);
