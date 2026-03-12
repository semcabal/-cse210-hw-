using System;
using System.Collections.Generic;

class PromptGenerator
{
    public List<string> _prompts = new List<string>()
    {
        "What made you smile today?",
        "What was the best part of your day?",
        "What challenge did you face today?",
        "What are you grateful for today?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);

        return _prompts[index];
    }
}