using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    abstract class Goal
    {
        public string _name;
        public string _description;
        public int _points;
        public bool _completed;

        public Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
            _completed = false;
        }

        public abstract int CalculatePoints();
    }

    class SimpleGoal : Goal
    {
        public SimpleGoal(string name, string description, int points) : base(name, description, points)
        {
        }

        public override int CalculatePoints()
        {
            return _completed ? _points : 0;
        }
    }

    class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points) : base(name, description, points)
        {
        }

        public override int CalculatePoints()
        {
            return _completed ? _points : 0;
        }
    }

    class ChecklistGoal : Goal
    {
        public int _targetCount;
        public int _bonus;
        public int _completedCount;

        public ChecklistGoal(string name, string description, int points, int targetCount, int bonus) : base(name, description, points)
        {
            _targetCount = targetCount;
            _bonus = bonus;
            _completedCount = 0;
        }

        public override int CalculatePoints()
        {
            if (_completedCount == _targetCount)
            {
                _completed = true;
                return _points + _bonus;
            }
            return _points;
        }

        public void MarkCompleted()
        {
            _completedCount++;
        }
    }

    static List<Goal> goals = new List<Goal>();
    static int totalPoints = 0;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine($"You have {totalPoints} points.");
            Console.WriteLine("Menu Options");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save goals");
            Console.WriteLine("4. Load goals");
            Console.WriteLine("5. Record event");
            Console.WriteLine("6. Quit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateNewGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    Console.WriteLine("Thank you, Have a nice time!!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void CreateNewGoal()
    {
        Console.WriteLine("The types of Goals are");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist goal");
        Console.Write("Which type of goal would you like to choose?: ");
        int goalType = int.Parse(Console.ReadLine());

        Console.Write("What is the name of your goal?: ");
        string name = Console.ReadLine();
        Console.Write("What is the short description of it?: ");
        string description = Console.ReadLine();
        Console.WriteLine("What is the amount of points associated with this goal?: ");
        int points = int.Parse(Console.ReadLine());

        Goal goal;

        switch (goalType)
        {
            case 1:
                goal = new SimpleGoal(name, description, points);
                break;
            case 2:
                goal = new EternalGoal(name, description, points);
                break;
            case 3:
                Console.WriteLine("How many times does this goal need to be accomplished for a bonus?: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.WriteLine("What is the bonus for accomplishing it that many times?: ");
                int bonus = int.Parse(Console.ReadLine());
                goal = new ChecklistGoal(name, description, points, targetCount, bonus);
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        goals.Add(goal);
        Console.WriteLine("Choice has been saved successfully.");
    }

    static void ListGoals()
    {
        Console.WriteLine("List of Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            string status = goals[i]._completed ? "[X]" : "[ ]";
            if (goals[i] is ChecklistGoal checklistGoal)
            {
                status = $"Completed {checklistGoal._completedCount}/{checklistGoal._targetCount} times";
            }
            Console.WriteLine($"{i + 1}. {status} {goals[i]._name} - {goals[i]._description}");
        }
    }

    static void SaveGoals()
    {
        Console.Write("Enter the filename for the goal file: ");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Goal goal in goals)
            {
                writer.WriteLine($"{goal.GetType().Name};{goal._name};{goal._description};{goal._points};{goal._completed}");
                if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine($"{checklistGoal._targetCount};{checklistGoal._bonus};{checklistGoal._completedCount}");
                }
            }
            Console.WriteLine("Goals have been saved successfully.");
        }
            using (StreamWriter writer = new StreamWriter("score.txt"))
        {
            writer.WriteLine($"TotalPoints:{totalPoints}");
            Console.WriteLine("Score has been saved successfully.");
        }
    }

    static void LoadGoals()
    {
        Console.Write("Enter the filename for the goal file: ");
        string filename = Console.ReadLine();
        goals.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            while (!reader.EndOfStream)
            {
                string[] data = reader.ReadLine().Split(';');
                string type = data[0];
                string name = data[1];
                string description = data[2];
                int points = int.Parse(data[3]);
                bool completed = bool.Parse(data[4]);

                if (type == nameof(SimpleGoal))
                {
                    goals.Add(new SimpleGoal(name, description, points) { _completed = completed });
                }
                else if (type == nameof(EternalGoal))
                {
                    goals.Add(new EternalGoal(name, description, points) { _completed = completed });
                }
                else if (type == nameof(ChecklistGoal))
                {
                    int targetCount = int.Parse(data[5]);
                    int bonus = int.Parse(data[6]);
                    int completedCount = int.Parse(data[7]);
                    goals.Add(new ChecklistGoal(name, description, points, targetCount, bonus) { _completed = completed, _completedCount = completedCount });
                }
            }
            Console.WriteLine("Goals have been loaded successfully.");
        }
    
        using (StreamReader reader = new StreamReader("score.txt"))
        {
            string scoreData = reader.ReadLine();
            if (scoreData != null && scoreData.StartsWith("TotalPoints:"))
            {
                totalPoints = int.Parse(scoreData.Split(':')[1]);
                Console.WriteLine($"Loaded score: {totalPoints}");
            }
        }
    }

    static void RecordEvent()
    {
        Console.WriteLine("The goals are");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i]._name}");
        }
        Console.Write("Which goal did you accomplish?: ");
        int choice = int.Parse(Console.ReadLine()) - 1;
        if (choice >= 0 && choice < goals.Count)
        {
            Goal goal = goals[choice];
            int pointsEarned = goal.CalculatePoints();

            goal._completed = true;
            Console.WriteLine($"Congratulations you have earned {pointsEarned} points!");
            totalPoints += pointsEarned;
        }
        else
        {
            Console.WriteLine("Invalid goal choice.");
        }
    }
}
