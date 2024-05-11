using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var scripture = new Scripture("John", 3, 16, "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have heverlasting life.");
        var hider = new ScriptureHider(scripture);
        hider.Run();
    }
}

class Scripture
{
    private readonly Reference reference;
    private readonly List<Word> words;

    public Scripture(string book, int chapter, int verse, string text)
    {
        reference = new Reference(book, chapter, verse);
        words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public Reference GetReference()
    {
        return reference;
    }

    public List<Word> GetWords()
    {
        return words;
    }

    public void HideRandomWord()
    {
        Random rand = new Random();
        var visibleWords = words.Where(word => !word.IsHidden()).ToList();
        if (visibleWords.Any())
        {
            var randomWord = visibleWords[rand.Next(visibleWords.Count)];
            randomWord.Hide();
        }
    }

    public bool IsCompletelyHidden()
    {
        return words.All(word => word.IsHidden());
    }
}

class Reference
{
    private readonly string book;
    private readonly int chapter;
    private readonly int verse;

    public Reference(string book, int chapter, int verse)
    {
        this.book = book;
        this.chapter = chapter;
        this.verse = verse;
    }

    public string GetDisplayText()
    {
        return $"{book} {chapter}:{verse}";
    }
}

class Word
{
    private readonly string text;
    private bool isHidden;

    public Word(string text)
    {
        this.text = text;
        isHidden = false;
    }

    public string GetDisplayText()
    {
        return isHidden ? "_____" : text;
    }

    public void Hide()
    {
        isHidden = true;
    }

    public void Show()
    {
        isHidden = false;
    }

    public bool IsHidden()
    {
        return isHidden;
    }
}

class ScriptureHider
{
    private readonly Scripture scripture;

    public ScriptureHider(Scripture scripture)
    {
        this.scripture = scripture;
    }

    public void Run()
    {
        DisplayScripture();

        while (!scripture.IsCompletelyHidden())
        {
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit: ");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWord();
            DisplayScripture();
        }

        Console.WriteLine("\nYou choose to quit. Ending program.");
    }

    private void DisplayScripture()
    {
        Console.Clear();
        Console.WriteLine(scripture.GetReference().GetDisplayText());
        foreach (var word in scripture.GetWords())
        {
            Console.Write($"{word.GetDisplayText()} ");
        }
        Console.WriteLine();
    }
}