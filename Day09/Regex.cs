using System.Text.RegularExpressions;

class RegexExample
{
    public static void Run()
    {
        string input = "Error: Timeout while calling API";
        string pattern = @"timeout";

    // Creating Regex object
    // IgnoreCase -> case-insensitive matching
    // TimeSpan -> timeout to prevent performance issues
        var rx = new Regex(
            pattern,
            RegexOptions.IgnoreCase,
            TimeSpan.FromMilliseconds(150)
        );

        bool isMatch = rx.IsMatch(input);

        Console.WriteLine("Pattern found: " + isMatch);
    }
}