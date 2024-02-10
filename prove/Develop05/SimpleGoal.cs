using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public bool IsCompleted
    {
        get { return _isComplete; }
        set { _isComplete = value; }
    }

    public override void RecordEvent()
    {
        if (!_isComplete)
        {
            Console.WriteLine($"{_shortName} event recorded! You earned {_points} points.");
            _isComplete = true;
        }
        else
        {
            Console.WriteLine($"{_shortName} has already been completed.");
        }
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"{base.GetStringRepresentation()} - Completed: {_isComplete}";
    }
}
