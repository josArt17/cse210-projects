using System;
using System.Collections.Generic;
using System.IO;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public virtual void Start(int duration)
    {
        _duration = duration;
        Console.WriteLine($"\n{_name} - {_description}");
        PrepareToBegin();
    }

    protected void PrepareToBegin()
    {
        Console.WriteLine("Get ready to begin...");
        Countdown(3);
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine($"Countdown: {i}...");
            Thread.Sleep(1000);
        }
    }

    public virtual void Finish()
    {
        Console.WriteLine("Good job!");
        Console.WriteLine($"You have completed {_name} for {_duration} seconds.");
        LogActivity();
        Countdown(3);
    }

    private void LogActivity()
    {
        string logFileName = "activity_log.txt";

        try
        {
            using (StreamWriter writer = new StreamWriter(logFileName, true))
            {
                writer.WriteLine($"{DateTime.Now} - Completed activity: {_name}");
            }

            Console.WriteLine($"Activity log has been updated: {logFileName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while updating activity log: {ex.Message}");
        }
    }
}