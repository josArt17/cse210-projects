using System;

public class UserInput
{
    public string GetEmailFromUser()
    {
        Console.Write("Enter the email address to send the report: ");
        return Console.ReadLine();
    }
}
