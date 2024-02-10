using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"{Name} event recorded! You earned {Points} points.");
    }

    public override bool IsComplete()
    {
        // Implementa la lógica para determinar si el objetivo eterno está completo
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"{Name} - {Description} - {Points} points (Eternal)";
    }
}
