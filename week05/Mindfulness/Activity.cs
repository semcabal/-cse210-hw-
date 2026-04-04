using System;
using System.Threading;

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    protected int Duration
    {
        get { return _duration; }
    }

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"=== {_name} ===");
        Console.WriteLine(_description);
        Console.WriteLine();

        _duration = ReadPositiveInteger("Enter the duration in seconds: ");

        Console.WriteLine();
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
        Console.WriteLine();
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(2);
        Console.WriteLine();
        Console.WriteLine($"You have completed the {_name} for {_duration} seconds.");
        ShowSpinner(2);
        Console.WriteLine();
    }

    protected void ShowSpinner(int seconds)
    {
        char[] spinner = { '|', '/', '-', '\\' };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int index = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write($"\r{spinner[index % spinner.Length]}");
            Thread.Sleep(200);
            index++;
        }

        Console.Write("\r \r");
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{i} ");
            Thread.Sleep(1000);
        }

        Console.Write("\r  \r");
    }

    private int ReadPositiveInteger(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";

            if (int.TryParse(input, out int number) && number > 0)
            {
                return number;
            }

            Console.WriteLine("Please enter a whole number greater than 0.");
        }
    }
}