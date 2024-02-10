using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
    }

    public int AmountCompleted
    {
        get { return _amountCompleted; }
        set { _amountCompleted = value; }
    }

    public int Target => _target;

    public int Bonus => _bonus;

    public override void RecordEvent()
    {
        if (!IsComplete())
        {
            _amountCompleted++;
            Console.WriteLine($"{Name} event recorded! You earned {Points} points.");

            if (IsComplete())
            {
                Console.WriteLine($"Congratulations! You achieved the bonus for {Name}. Bonus: {Points + _bonus} points.");
            }
        }
        else
        {
            Console.WriteLine($"{Name} has already been completed.");
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted == _target;
    }

    public override string GetDetailString()
    {
        return $"{Name} - {Description} - {Points} points - Completed {_amountCompleted}/{_target} times";
    }

    public override string GetStringRepresentation()
    {
        return $"{Name} - {Points} points - Checklist Goal";
    }
}
