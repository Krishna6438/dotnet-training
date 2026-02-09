using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

class Order
{
    public int Id;
}

public class OrderProcessing
{
    public static async Task Run()
    {
        var queue = new BlockingCollection<Order>();
        int processedCount = 0;

        // 🧑‍🏭 Producer
        Task producer = Task.Run(() =>
        {
            for (int i = 1; i <= 10; i++)
            {
                queue.Add(new Order { Id = i });
                Console.WriteLine($"Produced Order {i}");
            }
            queue.CompleteAdding(); // ✅ signal no more orders
        });

        // 👷 3 Consumers
        Task[] consumers = new Task[3];
        for (int i = 0; i < 3; i++)
        {
            consumers[i] = Task.Run(() =>
            {
                foreach (var order in queue.GetConsumingEnumerable())
                {
                    Console.WriteLine($"Processing Order {order.Id}");
                    Thread.Sleep(500); // simulate work
                    Interlocked.Increment(ref processedCount);
                }
            });
        }

        await producer;
        await Task.WhenAll(consumers);

        Console.WriteLine($"\nTotal Orders Processed: {processedCount}");
    }
}
