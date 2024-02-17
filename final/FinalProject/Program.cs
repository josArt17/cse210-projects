using System;

class Program
{
    static void Main(string[] args)
    {
        var emailConnection = new EmailConnection();
        var emailSender = new EmailSender(emailConnection);
        var userInput = new UserInput();
        var logger = new Logger();

        string toEmail = userInput.GetEmailFromUser();

        logger.LogSuccessfulEmail(toEmail);
    }
}