using System;
using System.Collections.Generic;

// Class to store statistics related to a content creator
public class CreatorStats
{
    public string? CreatorName { get; set; }
    public double[]? WeeklyLikes { get; set; }
}

public class StreamBuzz
{
    // List to maintain all registered creators
    private List<CreatorStats> EngagementBoard = new List<CreatorStats>();

    // Registers a creator record
    public void RegisterCreator(CreatorStats record)
    {
        EngagementBoard.Add(record);
    }

    // Returns a dictionary of creators and count of weeks
    // where likes are >= given threshold
    public Dictionary<string, int> GetTopPostCounts(double likeThreshold)
    {
        Dictionary<string, int> result = new Dictionary<string, int>();

        foreach (var creator in EngagementBoard)
        {
            int count = 0;

            foreach (double likes in creator.WeeklyLikes)
            {
                if (likes >= likeThreshold)
                {
                    count++;
                }
            }

            if (count > 0)
            {
                result[creator.CreatorName] = count;
            }
        }

        return result;
    }

    // Calculates overall average weekly likes
    public double CalculateAverageLikes()
    {
        double totalLikes = 0;
        int totalWeeks = 0;

        foreach (var creator in EngagementBoard)
        {
            foreach (double likes in creator.WeeklyLikes)
            {
                totalLikes += likes;
                totalWeeks++;
            }
        }

        return totalWeeks > 0 ? totalLikes / totalWeeks : 0;
    }

    // Application entry point
    public static void Run()
    {
        StreamBuzz app = new StreamBuzz();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n1. Register Creator");
            Console.WriteLine("2. Show Top Posts");
            Console.WriteLine("3. Calculate Average Likes");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    CreatorStats creator = new CreatorStats();

                    Console.Write("Enter Creator Name: ");
                    creator.CreatorName = Console.ReadLine();

                    creator.WeeklyLikes = new double[4];
                    Console.WriteLine("Enter weekly likes (4 weeks):");

                    for (int i = 0; i < 4; i++)
                    {
                        creator.WeeklyLikes[i] = Convert.ToDouble(Console.ReadLine());
                    }

                    app.RegisterCreator(creator);
                    Console.WriteLine("Creator registered successfully.");
                    break;

                case 2:
                    Console.Write("Enter like threshold: ");
                    double threshold = Convert.ToDouble(Console.ReadLine());

                    var topPosts = app.GetTopPostCounts(threshold);

                    if (topPosts.Count == 0)
                    {
                        Console.WriteLine("No top-performing creators.");
                    }
                    else
                    {
                        foreach (var item in topPosts)
                        {
                            Console.WriteLine($"{item.Key} - {item.Value} weeks");
                        }
                    }
                    break;

                case 3:
                    double average = app.CalculateAverageLikes();
                    Console.WriteLine("Overall average weekly likes: " + average);
                    break;

                case 4:
                    Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
