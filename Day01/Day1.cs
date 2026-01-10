using System;

class Day01
{
    public static void Run()
    {
        Console.WriteLine("Enter age:");
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int age))
        {
            bool isAdult = age >= 18;
            Console.WriteLine("Adult? " + isAdult);
        }
        else
        {
            Console.WriteLine("Invalid age");
        }
    }
}


// class Pro
// {
//     static void Main()
//     {
//         Console.WriteLine("Enter your name:");
//         string? name = Console.ReadLine();
//         Console.WriteLine($"Hello, {name}!");
//     }
// }
