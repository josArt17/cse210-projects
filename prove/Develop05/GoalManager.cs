using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();

    private List<Reward> _rewards = new List<Reward>();
    private int _score;

    public void AddReward()
    {   
        Console.WriteLine("Enter the new Reward");
        string name = Console.ReadLine();
        Console.WriteLine("\nEnter the points required for this Reward");
        int pointsRequired = int.Parse(Console.ReadLine());
        Reward newReward = new Reward(name, pointsRequired);
        _rewards.Add(newReward);
    }

    public void UpdateRewards()
    {
        foreach (var reward in _rewards)
        {
            reward.CheckClaimStatus(_score);
        }
    }

    public void Start()
    {
        int score = 0;
        Console.WriteLine("Main Menu");
        Console.WriteLine("------------------------------");
        

        while (true)
        {
            int currentScore = UserScore(score);
            Console.WriteLine($"\nYou have {currentScore} points \n");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Set Reward");
            Console.WriteLine("7. Quit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoalNames();
                    break;
                case 3:
                    SaveGoals(score);
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    AddReward();
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public int UserScore(int score)
    {
        _score += score;
        return _score;
    }

    public void ListGoalNames()
    {
        int numberItems = 0;
        Console.WriteLine("\nThe Goals are:\n");
        foreach (var goal in _goals)
        {
            numberItems += 1;
            string completionStatus = goal.IsComplete() ? "[X]" : "[ ]";

            if (goal is ChecklistGoal checklistGoal)
            {
                Console.WriteLine($"{numberItems}. {completionStatus} {checklistGoal.Name} ({checklistGoal.Description}) -- Currently completed {checklistGoal.AmountCompleted}/{checklistGoal.Target}");
            }
            else
            {
                Console.WriteLine($"{numberItems}. {completionStatus} {goal.Name} ({goal.Description})");
            }
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Choose the type of goal:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        int goalTypeChoice = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the goal name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter the goal description:");
        string description = Console.ReadLine();

        Console.WriteLine("Enter the goal points:");
        int points = int.Parse(Console.ReadLine());

        switch (goalTypeChoice)
        {
            case 1:
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case 2:
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case 3:
                Console.WriteLine("Enter the target amount:");
                int target = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the bonus points:");
                int bonus = int.Parse(Console.ReadLine());

                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type choice.");
                break;
        }
    }


    public void RecordEvent()
    {
        int numberItems = 0;
        Console.WriteLine("\nThe Goals are:\n");
        foreach (var goal in _goals)
        {
            numberItems += 1;

            if (goal is ChecklistGoal checklistGoal)
            {
                Console.WriteLine($"{numberItems}. {checklistGoal.Name}");
            }
            else
            {
                Console.WriteLine($"{numberItems}. {goal.Name}");
            }
        }

        Console.WriteLine("Enter the number of the goal you completed:");
        int goalNumber = int.Parse(Console.ReadLine());

        
        if (goalNumber >= 1 && goalNumber <= _goals.Count)
        {
            Goal selectedGoal = _goals[goalNumber - 1];

            
            if (selectedGoal is EternalGoal eternalGoal)
            {
                UserScore(eternalGoal.Points);
                Console.WriteLine($"Event recorded for {eternalGoal.Name}. You earned {eternalGoal.Points} points. Total score: {_score}");
                UpdateRewards();
            }
            else if(selectedGoal is SimpleGoal simpleGoal)
            {
                UserScore(simpleGoal.Points);
                simpleGoal.IsCompleted = true;
                Console.WriteLine($"Event recorded for {simpleGoal.Name}. You earned {simpleGoal.Points} points. Total score: {_score}");
                UpdateRewards();
            }
            else if (selectedGoal is ChecklistGoal checklistGoal)
            {
                if (checklistGoal.AmountCompleted < checklistGoal.Target)
                {
                    checklistGoal.AmountCompleted++;
                    UserScore(checklistGoal.Points);
                    Console.WriteLine($"Event recorded for {checklistGoal.Name}. You earned {checklistGoal.Points} points. Total score: {_score}");

                    if (checklistGoal.AmountCompleted == checklistGoal.Target)
                    {
                        _score += checklistGoal.Bonus;
                        Console.WriteLine($"Goal {checklistGoal.Name} completed! You earned a bonus of {checklistGoal.Bonus} points. Total score: {_score}");
                    }
                    UpdateRewards();
                }
                else
                {
                    Console.WriteLine($"Goal {checklistGoal.Name} has already been completed.");
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid goal number. Please enter a valid goal number.");
        }
    }


    public void SaveGoals(int score)
    {
        Console.WriteLine("Enter the name of the file to save goals:");
        string fileName = Console.ReadLine();

        try
        {
            
            using (StreamWriter writer = new StreamWriter($"{fileName}"))
            {
                writer.WriteLine(_score);
                foreach (var goal in _goals)
                {
                    if (goal is SimpleGoal simpleGoal)
                    {
                        writer.WriteLine($"SimpleGoal:{simpleGoal.Name},{simpleGoal.Description},{simpleGoal.Points},{simpleGoal.IsComplete()}");
                    }
                    else if (goal is EternalGoal eternalGoal)
                    {
                        writer.WriteLine($"EternalGoal:{eternalGoal.Name},{eternalGoal.Description},{eternalGoal.Points}");
                    }
                    else if (goal is ChecklistGoal checklistGoal)
                    {
                        writer.WriteLine($"ChecklistGoal:{checklistGoal.Name},{checklistGoal.Description},{checklistGoal.Points},{checklistGoal.Bonus},{checklistGoal.Target},{checklistGoal.AmountCompleted}");
                    }
                }

                foreach (var reward in _rewards)
                {
                    writer.WriteLine($"Reward:{reward.Name},{reward.PointsRequired},{reward.IsClaimed}");
                }
            }

            

            Console.WriteLine($"Goals saved successfully to {fileName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }


    public void LoadGoals()
    {
        Console.WriteLine("Enter the name of the file to load goals from:");
        string fileName = Console.ReadLine();

        try
        {
            using (StreamReader reader = new StreamReader($"{fileName}"))
            {
                _goals.Clear();
                _rewards.Clear();

                string scoreLine = reader.ReadLine();
                if (int.TryParse(scoreLine, out int loadedScore))
                {
                    _score = loadedScore;
                }

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length == 2)
                    {
                        string[] goalInfo = parts[1].Split(',');

                        if (goalInfo.Length >= 3)
                        {
                            string name = goalInfo[0];
                            string description = goalInfo[1];
                            int points = int.Parse(goalInfo[2]);

                            Goal newGoal;

                            switch (parts[0])
                            {
                                case "SimpleGoal":
                                    bool isComplete = bool.Parse(goalInfo[3]);
                                    newGoal = new SimpleGoal(name, description, points) { IsCompleted = isComplete };
                                    break;
                                case "EternalGoal":
                                    newGoal = new EternalGoal(name, description, points);
                                    break;
                                case "ChecklistGoal":
                                    int bonus = int.Parse(goalInfo[3]);
                                    int target = int.Parse(goalInfo[4]);
                                    int amountCompleted = int.Parse(goalInfo[5]);
                                    newGoal = new ChecklistGoal(name, description, points, target, bonus) { AmountCompleted = amountCompleted };
                                    break;
                                case "Reward":
                                    int pointsRequired = int.Parse(goalInfo[1]);
                                    bool isClaimed = bool.Parse(goalInfo[2]);
                                    Reward newReward = new Reward(name, pointsRequired) { IsClaimed = isClaimed };
                                    _rewards.Add(newReward);
                                    continue;
                                default:
                                    Console.WriteLine("Error from the data in file");
                                    continue;
                            }

                            _goals.Add(newGoal);
                        }
                    }
                }
            }

            Console.WriteLine($"Goals loaded successfully from {fileName}.txt");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }

}
