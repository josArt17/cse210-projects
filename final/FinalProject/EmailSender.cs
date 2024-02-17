using System;
using System.Net.Mail;
using System.Net.Mime;

public class EmailSender : FileHandler
{
    private readonly EmailConnection emailConnection;

    public EmailSender(EmailConnection emailConnection)
    {
        this.emailConnection = emailConnection;
    }

    public void SendEmail(string toEmail, string attachmentPath)
    {
        string htmlMessage = GetHtmlMessage();

        var message = CreateEmailMessage(toEmail, htmlMessage, attachmentPath);

        SendEmail(message);

        Console.WriteLine($"Message delivery to: {toEmail}");
    }

    private string GetHtmlMessage()
    {
        return @"
            <html>
            <style>
                .logo-img {
                    width: 100px;
                }
            </style>
            <body>
            <header>
                <img src=""some_img.png"" class=""logo-img"">
            </header>
            <h1>Hello</h1>
            <p>Sending you the weekly report of the branch sales data, I'm attaching it as an Excel file.</p>
            <p>Gretings</p>
            </body>
            </html>
        ";
    }

    private MailMessage CreateEmailMessage(string toEmail, string htmlMessage, string attachmentPath)
    {
        var message = new MailMessage
        {
            Subject = "Some subject",
            From = new MailAddress("email@mail.com"),
            Body = htmlMessage,
            IsBodyHtml = true
        };

        message.To.Add(toEmail);

        var htmlView = AlternateView.CreateAlternateViewFromString(htmlMessage, null, "text/html");
        message.AlternateViews.Add(htmlView);

        var attachment = CreateAttachment(attachmentPath);
        message.Attachments.Add(attachment);

        return message;
    }

    private Attachment CreateAttachment(string attachmentPath)
    {
        var fileContent = ReadFromFile(attachmentPath);
        var attachment = new Attachment(new MemoryStream(fileContent), "report.xlsx");
        attachment.ContentDisposition.CreationDate = File.GetCreationTime(attachmentPath);
        attachment.ContentDisposition.ModificationDate = File.GetLastWriteTime(attachmentPath);
        attachment.ContentDisposition.ReadDate = File.GetLastAccessTime(attachmentPath);
        return attachment;
    }

    private void SendEmail(MailMessage message)
    {
        using (var client = emailConnection.GetSmtpClient())
        {
            client.Send(message);
        }
    }
}
