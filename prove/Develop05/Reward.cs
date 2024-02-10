using System;

public class Reward
{
    public string Name { get; }
    public int PointsRequired { get; }
    public bool IsClaimed { get; set; }

    public Reward(string name, int pointsRequired)
    {
        Name = name;
        PointsRequired = pointsRequired;
        IsClaimed = false;
    }

    public void CheckClaimStatus(int currentScore)
    {
        if (!IsClaimed && currentScore >= PointsRequired)
        {
            IsClaimed = true;
            Console.WriteLine($"Congratulations! You've reached the goal for '{Name}' and claimed the reward.");
        }
        else if (!IsClaimed)
        {
            int pointsRemaining = PointsRequired - currentScore;
            Console.WriteLine($"You need {pointsRemaining} more points to claim the reward for '{Name}'. Keep going!");
        }
    }
}
