using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();

        bool quit = false;
        while (!quit)
        {
            Console.WriteLine($"\nYou have {manager.GetScore()} points.");

            DisplayMenu();

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal(manager);
                    break;
                case "2":
                    manager.ListGoalDetails();
                    break;
                case "3":
                    SaveGoals(manager);
                    break;
                case "4":
                    LoadGoals(manager);
                    break;
                case "5":
                    manager.RecordEvent();
                    break;
                case "6":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a number between 1 and 6.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("\nMenu Options:");
        Console.WriteLine("_____________________");
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Save Goals");
        Console.WriteLine("4. Load Goals");
        Console.WriteLine("5. Record Event");
        Console.WriteLine("6. Quit");
        Console.WriteLine("------------------------");
        Console.Write("Select a choice from the menu: ");
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("\nWhich type of Goals are?");
        Console.WriteLine("_________________");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("-------------------");
        Console.Write("\nWhich type of Goal would you like to create? ");
        string goalTypeChoice = Console.ReadLine();

        switch (goalTypeChoice)
        {
            case "1":
                manager.CreateSimpleGoal();
                break;
            case "2":
                manager.CreateEternalGoal();
                break;
            case "3":
                manager.CreateChecklistGoal();
                break;
            default:
                Console.WriteLine("Invalid choice. Please select a number between 1 and 3.");
                break;
        }
    }

    static void SaveGoals(GoalManager manager)
    {
        Console.Write("Enter the filename to save to: ");
        string saveFilename = Console.ReadLine();
        manager.SaveGoals(saveFilename);
    }

    static void LoadGoals(GoalManager manager)
    {
        Console.Write("Enter the filename to load from: ");
        string loadFilename = Console.ReadLine();
        manager.LoadGoals(loadFilename);
    }
}
