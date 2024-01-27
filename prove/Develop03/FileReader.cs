using System;
using System.IO;
using System.Collections.Generic;

public class FileReader
{
    public static RandomVerseResult ReadRandomVerseFromFile(string filePath)
    {
        try 
        {
            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length == 0)
            {
                Console.WriteLine("Error: El archivo está vacío.");
                return null;
            }

            Random random = new Random();
            string randomVerse = lines[random.Next(lines.Length)];

            Console.WriteLine($"Random Verse: {randomVerse}");

            string referenceString = randomVerse.Substring(0, randomVerse.IndexOf(':') + 6);
            Console.WriteLine($"Reference String: {referenceString}");

            Reference reference = ParseReference(referenceString);

            if (reference == null)
            {
                Console.WriteLine("Error: Reference is null after ParseReference.");
            }

            return new RandomVerseResult { VerseText = randomVerse, Reference = reference };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return null;
        }
    }

    private static Reference ParseReference(string referenceString)
    {
        int spaceIndex = referenceString.IndexOf(' ');

        if (spaceIndex == -1 || spaceIndex == referenceString.Length - 1)
        {
            Console.WriteLine("Error: Incorect Format");
            return null;
        }

        string book = referenceString.Substring(0, spaceIndex);
        string restOfReference = referenceString.Substring(spaceIndex + 1);

        string[] parts = restOfReference.Split(':');
        if (parts.Length != 2)
        {
            Console.WriteLine("Error: Incorrect Format.");
            return null;
        }

        int chapter;
        if (!int.TryParse(parts[0], out chapter))
        {
            Console.WriteLine("Error: Cant convert to int.");
            return null;
        }

        int verseStart, verseEnd;

        if (parts[1].Contains('-'))
        {
            string[] verseRange = parts[1].Split('-');
            if (verseRange.Length != 2 || !int.TryParse(verseRange[0], out verseStart) || !int.TryParse(verseRange[1], out verseEnd))
            {
                Console.WriteLine("Error: incorrect format");
                return null;
            }
        }
        else
        {
            if (!int.TryParse(parts[1], out verseStart))
            {
                Console.WriteLine("Error: cant convert to int");
                return null;
            }
            verseEnd = verseStart;
        }

        return new Reference(book, chapter, verseStart, verseEnd);
    }

    public class RandomVerseResult
{
    public string VerseText { get; set; }
    public Reference Reference { get; set; }
}
}