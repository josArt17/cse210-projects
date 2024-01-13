using System;

class Program
{
    static void Main(string[] args)
    {
        static void Hello ()
        {
            Console.Write("Welcome to the program!\n");
        }

        static string NameOfUser ()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }

        static int SquareNumber ()
        {
            Console.Write("Please enter your favorite number: ");
            int number = int.Parse(Console.ReadLine());
            int squareNumber = number * number;
            return squareNumber;
        }

        static void Main ()
        {
            Hello ();
            string name = NameOfUser ();
            int number = SquareNumber ();
            Console.Write($"{name}, the square of your number is {number}");
        }

        Main ();
    }
}