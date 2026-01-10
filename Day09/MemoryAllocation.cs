using System;
using System.Collections.Generic;

class MemoryAllocation
{
    public static void Run()
    {
        // List to hold references of allocated memory blocks
        List<byte[]> list = new List<byte[]>();

        // Loop to allocate memory
        for (int i = 0; i < 20000; i++)
        {
            // Allocating 1 KB (1024 bytes) on the managed heap
            list.Add(new byte[1024]);
        }

        Console.WriteLine("Memory Allocated");

        // Get total memory currently allocated
        // forceFullCollection = false → does NOT force GC
        long totalMemory = GC.GetTotalMemory(forceFullCollection: false);

        Console.WriteLine("Total memory (bytes): " + totalMemory);
    }
}
