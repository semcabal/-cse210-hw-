using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // Exceeds requirements:
        // The prompts and questions are not repeated until the full list has been used once.
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice: ");

            string choice = Console.ReadLine() ?? "";

            if (choice == "1")
            {
                BreathingActivity activity = new BreathingActivity();
                activity.Run();
                Pause();
            }
            else if (choice == "2")
            {
                ReflectingActivity activity = new ReflectingActivity();
                activity.Run();
                Pause();
            }
            else if (choice == "3")
            {
                ListingActivity activity = new ListingActivity();
                activity.Run();
                Pause();
            }
            else if (choice == "4")
            {
                return;
            }
            else
            {
                Console.WriteLine("Invalid choice.");
                Thread.Sleep(1000);
            }
        }
    }

    private static void Pause()
    {
        Console.WriteLine();
        Console.WriteLine("Press Enter to return to the menu...");
        Console.ReadLine();
    }
}