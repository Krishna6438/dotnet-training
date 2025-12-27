using System;
using System.Runtime.InteropServices;
using System.Text;

class GeneratePassword
{
    public string CleanseAndInvert(string input)
    {
        // Validation
        if (string.IsNullOrEmpty(input) || input.Length < 6)
            return "";

        // Check only alphabets
        foreach (char ch in input)
        {
            if (!char.IsLetter(ch))
                return "";
        }

        // Convert to lowercase
        input = input.ToLower();

        // Remove characters with even ASCII values
        List<char> res = new List<char>();
        foreach (char ch in input)
        {
            if (((int)ch) % 2 != 0)
            {
                res.Add(ch);
            }
        }

        

        

        res.Reverse();

        // Convert even index characters to uppercase
        for (int i = 0; i < res.Count; i++)
        {
            if (i % 2 == 0)
            {
                res[i] = char.ToUpper(res[i]);
            }
        }

        return new string(res.ToArray());

        
    }

    public static void Run()
    {
        GeneratePassword gp = new GeneratePassword();

        Console.WriteLine("Enter a string:");
        string? input = Console.ReadLine();

        string output = gp.CleanseAndInvert(input);

        if (output == "")
        {
            Console.WriteLine("Invalid Input");
        }
        else
        {
            Console.WriteLine("The generated key is - " + output);
        }
    }
}
