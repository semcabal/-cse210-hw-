using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("C# Basics", "John", 300);
        video1.AddComment(new Comment("Ana", "Very helpful!"));
        video1.AddComment(new Comment("Luis", "Nice explanation"));
        video1.AddComment(new Comment("Maria", "I learned a lot"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("OOP in C#", "Carlos", 450);
        video2.AddComment(new Comment("Pedro", "Great video"));
        video2.AddComment(new Comment("Lucia", "Clear and simple"));
        video2.AddComment(new Comment("Jose", "Thanks!"));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Lists in C#", "Sofia", 200);
        video3.AddComment(new Comment("Miguel", "Good examples"));
        video3.AddComment(new Comment("Elena", "Easy to understand"));
        video3.AddComment(new Comment("Raul", "Helpful"));
        videos.Add(video3);

        // Mostrar información
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Comments: {video.GetCommentCount()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}