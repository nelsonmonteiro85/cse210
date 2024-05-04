using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(" ");
        Console.WriteLine("*****Welcome to the Journal Program!*****\n");
        Console.WriteLine("Please, select one of the following options:");

        Journal journal = new Journal();
        bool exitRequested = false;

        while (!exitRequested)
        {
            Console.WriteLine("1 - Write a new entry.");
            Console.WriteLine("2 - Display the journal.");
            Console.WriteLine("3 - Save the journal.");
            Console.WriteLine("4 - Load a journal.");
            Console.WriteLine("5 - Exit.\n");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.WriteNewEntry();
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    Console.Write("Enter file name to save (.csv): ");
                    string saveFileName = Console.ReadLine();
                    journal.SaveJournalToFile(saveFileName);
                    break;
                case "4":
                    Console.Write("Enter file name to load (.csv): ");
                    string loadFileName = Console.ReadLine();
                    journal.LoadJournalFromFile(loadFileName);
                    break;
                case "5":
                    exitRequested = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}