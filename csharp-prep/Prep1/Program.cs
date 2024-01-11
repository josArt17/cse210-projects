using System;

class Program
{
    static void Main(string[] args)
    {

        Console.Write("What is your name?: ");
        string name = Console.ReadLine();

        Console.Write("What is your lastname?: ");
        string lastName = Console.ReadLine();

        Console.WriteLine($"Your name is {lastName}, {name} {lastName}");
    }
}