using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
        
        if (float.TryParse(answer, out float percent))
        {
            string letter = "";
            string symbol = "";

            if (percent >= 90)
            {
                letter = "A";
            }
            else if (percent >= 80)
            {
                letter = "B";
            }
            else if (percent >= 70)
            {
                letter = "C";
            }
            else if (percent >= 60)
            {
                letter = "D";
            }
            else
            {
                letter = "F";
            }

            if (percent >= 70)
            {
                float lastDigit = percent % 10;
                if (lastDigit >= 7)
                {
                    symbol = "+";
                }
                else if (lastDigit < 3)
                {
                    symbol = "-";
                }

                Console.WriteLine($"You passed, your grade is {letter}{symbol}");
            }
            else
            {
                Console.WriteLine("Better luck next time!");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
}