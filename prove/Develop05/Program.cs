using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();

        bool quit = false;
        while (!quit)
        {
            Console.WriteLine($"\nYou have {manager.GetScore()} points.");
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

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
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
                    break;

                case "2":
                    manager.ListGoalDetails();
                    break;
                case "3":
                    Console.Write("Enter the filename to save to: ");
                    string saveFilename = Console.ReadLine();
                    manager.SaveGoals(saveFilename);
                    break;
                case "4":
                    Console.Write("Enter the filename to load from: ");
                    string loadFilename = Console.ReadLine();
                    manager.LoadGoals(loadFilename);
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
}