using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {

        string filePath = "scriptures.txt";
        var result = FileReader.ReadRandomVerseFromFile(filePath);

        if (result == null)
        {
            Console.WriteLine("Error: Cant to read Reference.");
            return;
        }

        string randomVerse = result.VerseText;
        Reference reference = result.Reference;

        var randomScripture = new Scripture(reference, randomVerse);

        do
        {
            
            Console.WriteLine(randomScripture.GetDisplayText());

            
            Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
            var userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
                break;

            randomScripture.HideRandomWords(3);  

        } while (!randomScripture.IsCompletelyHidden());

        Console.WriteLine("All words hidden. Program ending.");
    }
    
}