using System;
using System.Threading;

public class ReflectionActivity : Activity
{
    private readonly string[] mainQuestions =
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private readonly string[] subQuestions =
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you feel when it was complete?",
        "What did you learn about yourself through this experience?"
    };

    public ReflectionActivity() : base("Reflection Activity", "Reflect on times you've shown strength and resilience.")
    {
    }

    public override void Start(int duration)
    {
        base.Start(duration);
        PerformReflectionActivity();
    }

    private void PerformReflectionActivity()
    {
        for (int i = 0; i < _duration; i++)
        {
            string mainQuestion = mainQuestions[new Random().Next(mainQuestions.Length)];
            Console.WriteLine($"\n{mainQuestion}");
            Countdown(3);
            i += 3;

            for (int j = 0; j < 2; j++)
            {
                string subQuestion = subQuestions[new Random().Next(subQuestions.Length)];
                Console.WriteLine(subQuestion);
                Spinner(3);
                i += 3;
            }
        }

        Finish();
    }

    private void Spinner(int seconds)
    {
        char[] spinChars = { '|', '/', '-', '\\' };

        for (int i = 0; i < seconds * 2; i++)
        {
            foreach (var spinChar in spinChars)
            {
                Console.Write($"Reflecting {spinChar}\r");
                Thread.Sleep(500);
            }
        }
    }
}
