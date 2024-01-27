using System;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        InitializeWords(text);   
    }

    private void InitializeWords(string text)
    {
        var wordArray = text.Split(' ');
        _words = wordArray.Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords(int numberToHide)
    {
        var random = new Random();

        for (int i = 0; i < numberToHide; i++)
        {
            var visibleWords = _words.Where(word => !word.IsHidden()).ToList();

            if (visibleWords.Count == 0)
                break;

            var randomWord = visibleWords[random.Next(visibleWords.Count)];
            randomWord.Hide();
        }
    }

    public string GetDisplayText()
    {

        var displayText = $"{_reference.GetDisplayText()}:\n";

        foreach (var word in _words)
        {
            displayText += word.GetDisplayText();
        }

        displayText += "\n";
        return displayText;
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }

    
}