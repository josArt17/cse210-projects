using System;
using System.Diagnostics;

class GetDataFromBd
{
    public string RunPythonScript()
    {
        
        string pythonScriptPath = "main.py";

        
        string outputPath = "report.xlsx";

        
        using (Process pythonProcess = new Process())
        {
            pythonProcess.StartInfo.FileName = @"C:/Users/user/AppData/Local/Programs/Python/Python311/python.exe";
            pythonProcess.StartInfo.Arguments = $"{pythonScriptPath} {outputPath}";
            pythonProcess.StartInfo.UseShellExecute = false;
            pythonProcess.StartInfo.RedirectStandardOutput = true;
            pythonProcess.StartInfo.RedirectStandardError = true;
            pythonProcess.StartInfo.CreateNoWindow = true;

            
            pythonProcess.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);
            pythonProcess.ErrorDataReceived += (sender, e) => Console.WriteLine("Error: " + e.Data);

            
            pythonProcess.Start();

            
            pythonProcess.BeginOutputReadLine();
            pythonProcess.BeginErrorReadLine();

            
            pythonProcess.WaitForExit();

            
            int exitCode = pythonProcess.ExitCode;
            Console.WriteLine($"{exitCode}");
        }

        return outputPath;
    }
}

