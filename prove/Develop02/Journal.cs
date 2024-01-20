using System;

public class Journal
{
   private List<Entry> entries = new List<Entry>();
   private PromptGenerator promptGenerator = new PromptGenerator();
   private int newEntriesCount = 0;

    public void WriteNewEntry()
    {
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine(prompt);
        Console.Write("Your Response: ");
        string response = Console.ReadLine();

        Entry entry = new Entry
        {
            _date = DateTime.Now.ToString(),
            _promptText = prompt,
            _entryText = response
        };

        entries.Add(entry);
        newEntriesCount++;
        Console.WriteLine("Entry added successfully!");
    }

    public void DisplayJournal()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.");
        }
        else
        {
            foreach (var entry in entries)
            {
                entry.Display();
            }
            
            Console.WriteLine($"Total of entries: {entries.Count}, New entries: {newEntriesCount}");
        }

    }

    public void ResetNewEntriesCount()
    {
        newEntriesCount = 0;
    }

    public void SaveJournalToFile()
    {
        Console.Write("Enter a filename to save the journal: ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in entries)
                {
                    writer.WriteLine($"{entry._date} - {entry._promptText}: {entry._entryText}");
                }
            }

            Console.WriteLine("Journal saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving the journal: {ex.Message}");
        }
    }

    public void LoadJournalFromFile()
    {
        Console.Write("Enter a filename to load the journal from: ");
        string filename = Console.ReadLine();

        try
        {
            List<Entry> loadedEntries = new List<Entry>();

            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {

                    string[] parts = line.Split(new[] { " - " }, StringSplitOptions.None);                
                    DateTime date = DateTime.Parse(parts[0]);
                    string[] entryParts = parts[1].Split(new[] {": "}, StringSplitOptions.None);
                    string prompt = entryParts[0];
                    string response = entryParts[1];

                    Entry entry = new Entry
                    {
                        _date = date.ToString(),
                        _promptText = prompt,
                        _entryText = response
                    };

                    loadedEntries.Add(entry);
                }
            }

            entries = loadedEntries;
            Console.WriteLine("Journal loaded successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading the journal: {ex.Message}");
        }
    }

    public int GetNewEntriesCount()
    {
        return newEntriesCount;
    }
}