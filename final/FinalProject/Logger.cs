using System;
using System.IO;

public class Logger
{
    private const string LogFilePath = "email_log.txt";

    public void LogSuccessfulEmail(string toEmail)
    {
        string logMessage = $"Successful email sent to: {toEmail} - {DateTime.Now}";
        File.AppendAllText(LogFilePath, logMessage + Environment.NewLine);
    }
}
