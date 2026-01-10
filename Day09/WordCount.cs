static class StringExtension
{
    public static int WordCount(String s)
    {
        char[] chars = s.ToCharArray();
        int count =1;
        foreach(var item in chars)
        {
            if(item == ' ')
            {
                count++;
            }
        }
        return count;

    }
}

public class WordCountClass
{
    public static void Run()
    {
        int a = StringExtension.WordCount("This is a pen.");
        Console.WriteLine(a);
    }
}