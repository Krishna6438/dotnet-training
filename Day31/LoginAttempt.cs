// TODO:
// 1. Allow only 3 login attempts
// 2. Create and throw custom exception after limit
// 3. Handle exception and terminate application

using System;

public class AttemptException : Exception
{
    public AttemptException() : base("Maximum login attempts exceeded.") { }
}

class LoginSystem
{
    public static void Run()
    {
        int maxAttempts = 3;
        int attempts = 0;

        try
        {
            while (attempts < maxAttempts)
            {
                Console.WriteLine($"Attempt {attempts + 1}: Enter password");
                Console.ReadLine(); // simulate input
                attempts++;
            }
            throw new AttemptException();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Application terminated.");
        }







    }
}