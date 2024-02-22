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
        string plainTextMessage = GetPlainTextMessage();

        var message = CreateEmailMessage(toEmail, plainTextMessage, attachmentPath);

        Console.WriteLine("Preparing to send message");

        deliverMessage(message);

        Console.WriteLine($"Message delivery to: {toEmail}");
    }

    private string GetPlainTextMessage()
    {
        return "Hello,\n\nSending you the weekly report of the branch sales data, I'm attaching it as an Excel file.\n\nGreetings";
    }

    private MailMessage CreateEmailMessage(string toEmail, string plainTextMessage, string attachmentPath)
    {
        var message = new MailMessage
        {
            Subject = "Some subject",
            From = new MailAddress("cuentas@arthecnology.com"),
            Body = plainTextMessage
        };

        message.To.Add(toEmail);

        var attachment = CreateAttachment(attachmentPath);
        message.Attachments.Add(attachment);

        message.BodyEncoding = System.Text.Encoding.UTF8;

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

    private void deliverMessage(MailMessage message)
    {
        try
        {
        
            using (var client = emailConnection.GetSmtpClient())
            {
                client.Send(message);
            }
        
            Console.WriteLine("Email sent successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending email: {ex.Message}");
        }
    }
}
