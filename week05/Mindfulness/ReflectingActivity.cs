using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private List<string> _availablePrompts;
    private List<string> _availableQuestions;
    private Random _random;

    public ReflectingActivity()
        : base(
            "Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _random = new Random();

        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        _availablePrompts = new List<string>(_prompts);
        _availableQuestions = new List<string>(_questions);
    }

    public void Run()
    {
        DisplayStartingMessage();
        DisplayPrompt();
        DisplayQuestions();
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

    private string GetRandomQuestion()
    {
        if (_availableQuestions.Count == 0)
        {
            _availableQuestions = new List<string>(_questions);
        }

        int index = _random.Next(_availableQuestions.Count);
        string question = _availableQuestions[index];
        _availableQuestions.RemoveAt(index);

        return question;
    }

    private void DisplayPrompt()
    {
        string prompt = GetRandomPrompt();

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine(prompt);
        Console.WriteLine();
        Console.WriteLine("You will begin in:");
        ShowCountDown(5);
        Console.WriteLine();
    }

    private void DisplayQuestions()
    {
        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine(GetRandomQuestion());
            ShowSpinner(5);
            Console.WriteLine();
        }
    }
}