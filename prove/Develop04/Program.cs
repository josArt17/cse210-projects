using System;
using System.Threading;

// CSE210 - JOSE ANGEL ARTEAGA
// EXCEED REQUIREMENTS, I ADD A LOG FILE FOR ALL THE ACTIVITIES, WHEN ONE ACTIVITY FINISH
// MY CODE SAVE DATE AND HOUR OF THAT ACTIVITY, AND FOR THE LISTINGACTIVITY I SAVE
// THE LIST OF ENTRIES OF THE USER
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            DisplayMenu();
            string userInput = Console.ReadLine();

            if (userInput == "0")
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            if (int.TryParse(userInput, out int activityChoice))
            {
                if (activityChoice >= 1 && activityChoice <= 3)
                {
                    Console.Write("Enter the duration in seconds: ");
                    if (int.TryParse(Console.ReadLine(), out int duration))
                    {
                        PerformSelectedActivity(activityChoice, duration);
                    }
                    else
                    {
                        Console.WriteLine("Invalid duration. Please enter a valid number.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("\nSelect an activity:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("0. Exit");
        Console.Write("Your choice: ");
    }

    static void PerformSelectedActivity(int choice, int duration)
    {
        Activity activity;

        switch (choice)
        {
            case 1:
                activity = new BreathingActivity();
                break;
            case 2:
                activity = new ReflectionActivity();
                break;
            case 3:
                activity = new ListingActivity();
                break;
            default:
                return;
        }

        activity.Start(duration);
        if (activity is ListingActivity)
        {
            ((ListingActivity)activity).PerformListingActivity();
        }
        else
        {
            activity.Finish();
        }
    }
}