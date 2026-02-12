using System;

public class EmailValidation
{
    public static bool IsValidEmail(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return false;
        }
        string[] parts = input.Split("@");
        string first = parts[0];
        string domain = parts[1];

        if (string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(domain))
        {
            return false;
        }

        foreach(char ch in first)
        {
            if (!char.IsLetterOrDigit(ch))
            {
                return false;
            }
        }

        foreach(char ch in domain)
        {
            int count = 0;
            if(ch == '@')
            {
                count++;
            }
            if (count > 1)
            {
                return false;
            }
        }

        return true;
            
    }
    public static void Run()
    {
        string? input = Console.ReadLine();
        bool valid = IsValidEmail(input);
        if (valid)
        {
            Console.WriteLine("Email is Valid");
        }
        else
        {
            Console.WriteLine("Email is invalid");
        }
    }
}