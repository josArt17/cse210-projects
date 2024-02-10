using System;
using System.Collections.Generic;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public GoalManager()
    {
        // Puedes agregar algunos objetivos predeterminados aquí si lo deseas
    }

    public void Start()
    {
        Console.WriteLine("Eternal Quest - Goal Manager");
        Console.WriteLine("------------------------------");

        while (true)
        {
            Console.WriteLine("\n1. Display Player Info");
            Console.WriteLine("2. List Goal Names");
            Console.WriteLine("3. List Goal Details");
            Console.WriteLine("4. Create Goal");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Save Goals");
            Console.WriteLine("7. Load Goals");
            Console.WriteLine("8. Exit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DisplayPlayerInfo();
                    break;
                case 2:
                    ListGoalNames();
                    break;
                case 3:
                    ListGoalDetails();
                    break;
                case 4:
                    CreateGoal();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 8:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nCurrent Score: {_score} points");
    }

    public void ListGoalNames()
{
    Console.WriteLine("\nGoal Names:");
    foreach (var goal in _goals)
    {
        Console.WriteLine(goal.Name);
    }
}


    public void ListGoalDetails()
    {
        Console.WriteLine("\nGoal Details:");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailString());
        }
    }

    public void CreateGoal()
    {
        // Puedes implementar la lógica para crear un nuevo objetivo aquí
        Console.WriteLine("Feature not implemented yet.");
    }

    public void RecordEvent()
{
    Console.WriteLine("Enter the goal name you accomplished:");
    string goalName = Console.ReadLine();

    Goal goal = _goals.Find(g => g.Name == goalName);

    if (goal != null)
    {
        goal.RecordEvent();
        if (!goal.IsComplete())
        {
            _score += goal.Points;
        }
    }
    else
    {
        Console.WriteLine("Goal not found.");
    }
}

}


