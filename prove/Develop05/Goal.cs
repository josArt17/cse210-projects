using System;

public class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public string Name => _shortName;
    public int Points => _points;
    public string Description => _description;

    public Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public virtual void RecordEvent()
    {
        Console.WriteLine($"{_shortName} event recorded! You earned {_points} points.");
    }

    public virtual bool IsComplete()
    {
        // La lógica de completado dependerá de las subclases
        return false;
    }

    public virtual string GetDetailString()
    {
        return $"{_shortName} - {_description} - {_points} points";
    }

    public virtual string GetStringRepresentation()
    {
        return $"{_shortName} - {_points} points";
    }
}
