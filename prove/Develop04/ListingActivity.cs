using System;
using System.Collections.Generic;
using System.IO;

public class ListingActivity : Activity
{
    private List<string> itemsList = new List<string>();

    public ListingActivity() : base("Listing Activity", "List as many things as you can based on the prompt.")
    {
    }

    public override void Start(int duration)
    {
        base.Start(duration);
        PerformListingActivity();
    }

    public void PerformListingActivity()
    {
        string[] prompts =
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        for (int i = 0; i < _duration; i++)
        {
            string prompt = prompts[new Random().Next(prompts.Length)];
            Console.WriteLine($"\n{prompt}");
            Countdown(3);
            i += 3;

            Console.WriteLine("Start listing... (Press Enter after each entry, type 'done' to finish)");

            string entry = "";

            while (true)
            {
                Console.Write("Type something: ");
                entry = Console.ReadLine();

                if (entry.ToLower() == "done")
                {
                    break;
                }

                itemsList.Add(entry);
            }
            i += _duration;
            Finish();
        }

        ShowListCount();
        SaveItemsToLog();
    }

    private void ShowListCount()
    {
        Console.WriteLine($"\nYou listed {itemsList.Count} items.");
    }

    private void SaveItemsToLog()
    {
        string logFileName = "listing_activity_log.txt";

        try
        {
            using (StreamWriter writer = new StreamWriter(logFileName))
            {
                foreach (var item in itemsList)
                {
                    writer.WriteLine(item);
                }
            }

            Console.WriteLine($"Items have been saved to {logFileName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving to log: {ex.Message}");
        }
    }
}
