using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        bool exit = false;

        while (!exit)
        {
            Console.Write("Please select one of the following choices: \n");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.WriteNewEntry();
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    journal.SaveJournalToFile();
                    break;
                case "4":
                    journal.LoadJournalFromFile();
                    break;
                case "5":
                    if (journal.GetNewEntriesCount() > 0)
                    {
                        Console.WriteLine($"Congratulations today you add: {journal.GetNewEntriesCount()} new entries");
                    }
                    else
                    {
                        Console.WriteLine("Always exist something interesting to share with the Journal, try again later");
                    }
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
                    break;
            }

            Console.WriteLine();
        }
    }
}