using System.Net;
using System.Net.Mail;

public class EmailConnection
{
    private const string Host = "HOST OF THE EMAIL";
    private const int Port = 0000;
    private const string User = "USER OF THE EMAIL";
    private const string Password = "PASSWORD";

    public SmtpClient GetSmtpClient()
    {
        return new SmtpClient(Host, Port)
        {
            Credentials = new NetworkCredential(User, Password),
            EnableSsl = true
        };
    }
}
