using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;
    private List<string> _availablePrompts;
    private Random _random;

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _count = 0;
        _random = new Random();
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        _availablePrompts = new List<string>(_prompts);
    }

    public void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        Console.WriteLine(prompt);
        Console.WriteLine();
        Console.WriteLine("You will begin in:");
        ShowCountDown(5);
        Console.WriteLine();
        Console.WriteLine("Start listing items. Press Enter after each one.");

        List<string> items = GetListFromUser();

        _count = items.Count;

        Console.WriteLine();
        Console.WriteLine($"You listed {_count} items.");

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        if (_availablePrompts.Count == 0)
        {
            _availablePrompts = new List<string>(_prompts);
        }

        int index = _random.Next(_availablePrompts.Count);
        string prompt = _availablePrompts[index];
        _availablePrompts.RemoveAt(index);

        return prompt;
    }

    private List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine() ?? "";

            if (!string.IsNullOrWhiteSpace(item))
            {
                items.Add(item.Trim());
            }
        }

        return items;
    }
}