using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== ETERNAL QUEST ===\n");
        Console.Write("Enter your name: ");
        string username = Console.ReadLine();

        UserProfile user = new UserProfile(username);

        string saveFile = $"{username}_progress.txt";
        user.LoadFromFile(saveFile);

        bool running = true;

        while (running)
        {
            Console.WriteLine("\n" + new string('=', 50));
            user.DisplayScore();
            Console.WriteLine("MAIN MENU:");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. List all goals");
            Console.WriteLine("3. Record goal progress");
            Console.WriteLine("4. Save progress");
            Console.WriteLine("5. Load progress");
            Console.WriteLine("6. Exit");
            Console.Write("\nSelect an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateNewGoal(user);
                    break;
                case "2":
                    user.DisplayGoals();
                    break;
                case "3":
                    RecordGoalProgress(user);
                    break;
                case "4":
                    user.SaveToFile(saveFile);
                    break;
                case "5":
                    user.LoadFromFile(saveFile);
                    break;
                case "6":
                    Console.WriteLine($"\nGoodbye {username}!");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void CreateNewGoal(UserProfile user)
    {
        Console.WriteLine("\n=== CREATE NEW GOAL ===");

        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Negative Goal");

        Console.Write("Select type: ");
        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Points: ");
        if (!int.TryParse(Console.ReadLine(), out int points))
        {
            Console.WriteLine("Invalid points.");
            return;
        }

        Goal newGoal = null;

        switch (type)
        {
            case "1":
                newGoal = new SimpleGoal(name, description, points);
                break;

            case "2":
                newGoal = new EternalGoal(name, description, points);
                break;

            case "3":
                Console.Write("Target: ");
                if (!int.TryParse(Console.ReadLine(), out int target)) return;

                Console.Write("Bonus: ");
                if (!int.TryParse(Console.ReadLine(), out int bonus)) return;

                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;

            case "4":
                newGoal = new NegativeGoal(name, description, points);
                break;

            default:
                Console.WriteLine("Invalid type.");
                return;
        }

        user.AddGoal(newGoal);
    }

    static void RecordGoalProgress(UserProfile user)
    {
        Console.WriteLine("\n=== RECORD PROGRESS ===");

        if (user.GetGoals().Count == 0)
        {
            Console.WriteLine("No goals.");
            return;
        }

        user.DisplayGoals();

        Console.Write("Select goal #: ");
        if (int.TryParse(Console.ReadLine(), out int index))
        {
            user.RecordGoalEvent(index - 1);
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }
}