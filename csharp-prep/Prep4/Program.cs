using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        bool finish = false;

        while (finish == false)
        {
            Console.Write("Enter number, type 0 when you finish: ");
            int number;
            if (int.TryParse(Console.ReadLine(), out number))
            {
                if (number != 0)
                {
                    numbers.Add(number);
                }
                else
                {
                    finish = true;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        numbers.Sort();

        int sum = 0;
        int lNumber = int.MinValue;
        int mNumber = int.MaxValue;

        foreach (int value in numbers)
        {
            sum += value;
            if (value > lNumber)
            {
                lNumber = value;
            }
            if (value < mNumber && value > 0)
            {
                mNumber = value;
            }
        }

        float avg = sum / numbers.Count;

        
        



        Console.Write($"The sum is: {sum}\n");
        Console.Write($"The average is: {avg}\n");
        Console.Write($"The largest number is: {lNumber}\n");
        Console.Write($"The smallest positive number is: {mNumber}\n");
        Console.Write("The sorted list is:\n");

        foreach (int item in numbers)
        {
            Console.Write($"{item}\n");
        }
    }
}