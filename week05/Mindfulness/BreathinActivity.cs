using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        int elapsed = 0;

        while (elapsed < Duration)
        {
            int inhaleTime = Math.Min(4, Duration - elapsed);
            Console.Write("Breathe in... ");
            ShowCountDown(inhaleTime);
            elapsed += inhaleTime;

            if (elapsed >= Duration)
            {
                break;
            }

            int exhaleTime = Math.Min(4, Duration - elapsed);
            Console.Write("Breathe out... ");
            ShowCountDown(exhaleTime);
            elapsed += exhaleTime;
        }

        DisplayEndingMessage();
    }
}