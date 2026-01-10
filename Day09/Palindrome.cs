public static class Palindrome
{
    public static bool IsPalindrome(this string str)
    {
        int left = 0;
        int right = str.Length - 1;

        while (left < right)
        {
            if (str[left] != str[right])
            {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }
}

public class PalindromeClass
{
    public static void Run()
    {
        bool IsPalindrome = Palindrome.IsPalindrome("Naman");
        Console.WriteLine(IsPalindrome);
    }
}
