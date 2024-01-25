using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction firstMethod = new Fraction();
        Console.WriteLine(firstMethod.GetFraction());
        Console.WriteLine(firstMethod.GetDecimal());
        
        Fraction secoundMethod = new Fraction(2);
        Console.WriteLine(secoundMethod.GetFraction());
        Console.WriteLine(secoundMethod.GetDecimal());

        Fraction thirdMethod = new Fraction(4, 9);
        Console.WriteLine(thirdMethod.GetFraction());
        Console.WriteLine(thirdMethod.GetDecimal());
    }
}