using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> entries;

    public Journal()
    {
        entries = new List<Entry>();
    }

    public void WriteNewEntry()
    {
        string[] prompts = {
            "What would you like to register about your day?",
            "What was the most important moment of your day?",
            "How do you feel today and, what would you like to accomplish?",
            "What was the strongest feeling you had today?",
            "If you could redo anything about today, what would it be?",
            "What important things happened to import people, around you?"
        };
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Length)];

        Console.WriteLine(prompt);
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        Entry newEntry = new Entry(prompt, response, DateTime.Now.ToString());
        entries.Add(newEntry);
    }

    public void DisplayJournal()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine();
        }
    }

    public void SaveJournalToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"\"{entry.Date}\",\"{Escape(entry.Prompt)}\",\"{Escape(entry.Response)}\"");
            }
        }

        Console.WriteLine("Journal saved to file successfully.");
    }

    public void LoadJournalFromFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            entries.Clear();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        string date = parts[0].Trim('"');
                        string prompt = Unescape(parts[1].Trim('"'));
                        string response = Unescape(parts[2].Trim('"'));
                        entries.Add(new Entry(prompt, response, date));
                    }
                }
            }
            Console.WriteLine("Journal loaded from file successfully.");
        }
        else
        {
            Console.WriteLine("File does not exist.");
        }
    }

    private string Escape(string value)
    {
        return value.Replace("\"", "\"\"");
    }

    private string Unescape(string value)
    {
        return value.Replace("\"\"", "\"");
    }
}

public class Entry
{
    public string Prompt { get; }
    public string Response { get; }
    public string Date { get; }

    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }
}