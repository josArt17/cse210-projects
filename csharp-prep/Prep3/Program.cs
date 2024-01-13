using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int number = random.Next(1, 101);
        int tries = 0;
        bool playAgain = true;

        while (playAgain)
        {
            Console.WriteLine("Welcome guess the number");
            Console.WriteLine();
            Console.Write("Write a number: ");
            double response = Convert.ToDouble(Console.ReadLine());

            while (response != number)
            {
                tries++;
                if (response > number)
                {
                    Console.WriteLine("Lower");
                    Console.WriteLine();
                    Console.Write("Write a number: ");
                    response = Convert.ToDouble(Console.ReadLine());
                }
                else if (response < number)
                {
                    Console.WriteLine("Higher");
                    Console.WriteLine();
                    Console.Write("Write a number: ");
                    response = Convert.ToDouble(Console.ReadLine());
                }
            }

            tries++;
            Console.WriteLine("You guessed it!");
            Console.WriteLine($"You had {tries} tries");
            Console.WriteLine();
            Console.Write("Do you wanna play again? ");
            string again = Console.ReadLine().ToLower();

            if (again == "yes")
            {
                playAgain = true;
                number = random.Next(1, 101);
            }
            else
            {
                playAgain = false;
                Console.WriteLine("See you");
            }
        }
    }
}