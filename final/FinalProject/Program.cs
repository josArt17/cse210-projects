using System;

class Program
{
    static void Main(string[] args)
    {
        var userInput = new UserInput();
        var toEmail = userInput.GetEmailFromUser();

        var getDataFromBd = new GetDataFromBd();
        string attachmentPath = getDataFromBd.RunPythonScript();

        var emailConnection = new EmailConnection();
        var emailSender = new EmailSender(emailConnection);
        var logger = new Logger();


        emailSender.SendEmail(toEmail, attachmentPath);
        
        logger.LogSuccessfulEmail(toEmail);
    }
}
