public class ReverseString
{
    
    public static void Run()
    {
        string? input = Console.ReadLine();
        char[] reversed = new char[input.Length];
        for(int i = 0; i < input.Length; i++)
        {
            reversed[i] = input[input.Length - 1 - i];
        }
        Console.WriteLine(new string(reversed));
    }
}