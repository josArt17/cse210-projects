using System;

public class  BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "Relax by breathing in and out slowly.")
    {

    }

    public override void Start(int duration)
    {
        base.Start(duration);
        PerformBreathingActivity();
    }

    private void PerformBreathingActivity()
    {
        for (int i = 0; i < _duration; i++)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(2000);
            i += 2;
            Console.WriteLine("Breathe out...");
            Thread.Sleep(2000);
            i += 2;
        }

        Finish();
    }
}