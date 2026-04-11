using System;
using System.Collections.Generic;
using System.IO;

public class UserProfile
{
    private string _username;
    private int _score;
    private int _level;
    private List<Goal> _goals;

    private string[] _titles = {
        "Novice", "Learner", "Explorer", "Warrior", "Knight",
        "Hero", "Champion", "Legend", "Epic", "Mythic", "Godly"
    };

    public UserProfile(string username)
    {
        _username = username;
        _score = 0;
        _level = 1;
        _goals = new List<Goal>();
    }

    public int GetScore() => _score;
    public int GetLevel() => _level;
    public string GetTitle() => _level < _titles.Length ? _titles[_level - 1] : _titles[_titles.Length - 1];
    
    public void AddPoints(int points)
    {
        _score += points;
        UpdateLevel();
    }

    private void UpdateLevel()
    {
        int newLevel = (_score / 1000) + 1;
        if (newLevel > _level)
        {
            _level = newLevel;
            Console.WriteLine($"\nCONGRATULATIONS! You reached LEVEL {_level} ({GetTitle()})!\n");
        }
    }

    public void AddGoal(Goal goal) 
    {
        _goals.Add(goal);
        Console.WriteLine($"Goal added. Total goals: {_goals.Count}");
    }
    
    public List<Goal> GetGoals() => _goals;

    public void DisplayGoals()
    {
        Console.WriteLine($"\n--- DISPLAYING {_goals.Count} GOALS ---");
        
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals registered.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordGoalEvent(int index)
    {
        if (index >= 0 && index < _goals.Count)
        {
            int pointsEarned = _goals[index].RecordEvent();
            if (pointsEarned != 0)
            {
                AddPoints(pointsEarned);
                string pointsText = pointsEarned > 0 ? $"+{pointsEarned}" : $"{pointsEarned}";
                Console.WriteLine($"\nRecorded '{_goals[index].GetName()}'! Points: {pointsText}");
                
                if (pointsEarned > 0 && _goals[index].IsCompleted())
                {
                    Console.WriteLine($"GOAL COMPLETED!");
                }
            }
            else
            {
                Console.WriteLine($"\n'{_goals[index].GetName()}' is already completed or cannot be recorded.");
            }
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"\n{_username} - Score: {_score} | Level {_level} ({GetTitle()})\n");
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine($"{_username},{_score},{_level}");
            
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine($"Progress saved to {filename}");
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            
            string[] profileData = lines[0].Split(',');
            _username = profileData[0];
            _score = int.Parse(profileData[1]);
            _level = int.Parse(profileData[2]);
            
            _goals.Clear();
            
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                string type = parts[0];
                string[] data = parts[1].Split(',');
                
                Goal goal = null;
                
                switch (type)
                {
                    case "SimpleGoal":
                        goal = new SimpleGoal(data[0], data[1], int.Parse(data[2]));
                        if (bool.Parse(data[3])) 
                        {
                            goal.RecordEvent();
                        }
                        break;
                    case "EternalGoal":
                        goal = new EternalGoal(data[0], data[1], int.Parse(data[2]));
                        break;
                    case "ChecklistGoal":
                        string name = data[0];
                        string description = data[1];
                        int points = int.Parse(data[2]);
                        int target = int.Parse(data[3]);
                        int bonus = int.Parse(data[4]);
                        int amountCompleted = int.Parse(data[5]);
                        
                        goal = new ChecklistGoal(name, description, points, target, bonus);
                        for (int j = 0; j < amountCompleted; j++)
                        {
                            goal.RecordEvent();
                        }
                        break;
                    case "NegativeGoal":
                        goal = new NegativeGoal(data[0], data[1], int.Parse(data[2]));
                        break;
                }
                
                if (goal != null) 
                {
                    _goals.Add(goal);
                }
            }
            
            Console.WriteLine($"Progress loaded from {filename}. Loaded {_goals.Count} goals.");
        }
        else
        {
            Console.WriteLine("File not found. Starting new profile.");
        }
    }
}