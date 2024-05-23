using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public int GetScore()
    {
        return _score;
    }

    public void CreateSimpleGoal()
    {
        Console.Write("Enter the name of the goal: ");
        string name = Console.ReadLine();
        Console.Write("Enter a description for the goal: ");
        string description = Console.ReadLine();
        Console.Write("Enter the points for completing the goal: ");
        int points = int.Parse(Console.ReadLine());

        SimpleGoal goal = new SimpleGoal(name, description, points);
        _goals.Add(goal);
    }

    public void CreateEternalGoal()
    {
        Console.Write("Enter the name of the goal: ");
        string name = Console.ReadLine();
        Console.Write("Enter a description for the goal: ");
        string description = Console.ReadLine();
        Console.Write("Enter the points for completing the goal: ");
        int points = int.Parse(Console.ReadLine());

        EternalGoal goal = new EternalGoal(name, description, points);
        _goals.Add(goal);
    }

    public void CreateChecklistGoal()
    {
        Console.Write("\nWhat is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());
        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
        int target = int.Parse(Console.ReadLine());
        Console.Write("What is the bonus for accomplishing it that many times? ");
        int bonus = int.Parse(Console.ReadLine());

        ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);
        _goals.Add(goal);
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have not defined any goals yet. ");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("\nSelect the goal you have completed:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        int choice = int.Parse(Console.ReadLine()) - 1;
        if (choice >= 0 && choice < _goals.Count)
        {
            int points = _goals[choice].RecordEvent();
            _score += points;
            Console.WriteLine($"Congratulations! You have earned {points} points!");

            // Check if the completed goal is a checklist goal
            if (_goals[choice] is ChecklistGoal && _goals[choice].IsComplete())
            {
                // Cast the goal to ChecklistGoal and then call the Complete method
                ((ChecklistGoal)_goals[choice]).Complete();
            }
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    public void SaveGoals(string filename)
    {
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Invalid filename. Goals not saved.");
            return;
        }

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_score);
                foreach (var goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("Goals saved.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

    public void LoadGoals(string filename)
    {
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);

            _goals.Clear();
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');
                string goalType = parts[0];
                switch (goalType)
                {
                    case "SimpleGoal":
                        _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                        break;
                    case "ChecklistGoal":
                        _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6])));
                        break;
                }
            }
            Console.WriteLine("Goals loaded.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
