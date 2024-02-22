using System;
using System.Net;
using System.Net.Mail;

public class EmailConnection
{
    private const string Host = "";
    private const int Port = 587;
    private const string User = "";
    private const string Password = "";

    public SmtpClient GetSmtpClient()
    {
        try
        {
            var client = new SmtpClient(Host, Port)
            {
                Credentials = new NetworkCredential(User, Password),
                EnableSsl = true
            };

            Console.WriteLine("SMTP Connection successful");
            return client;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"SMTP Connection failed. Error: {ex.Message}");
            throw;
        }
    }
}
