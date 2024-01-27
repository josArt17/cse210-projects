using System;
using System.IO;

// CSE210 W03 JOSE ANGEL ARTEAGA
// Requirements exceeded, I added to my code the ability to read scriptures from a .txt file.
//The code will display a random scripture each time the program 
//is initiated and will hide parts each time the enter key is pressed.
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