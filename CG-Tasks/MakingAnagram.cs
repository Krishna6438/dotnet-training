using System;
using System.Collections.Generic;

class MakingAnagram
{
    public static void Run()
    {
        string? word1 = Console.ReadLine();
        string? word2 = Console.ReadLine();

        Dictionary<char, int> freq1 = new Dictionary<char, int>();
        Dictionary<char, int> freq2 = new Dictionary<char, int>();

        
        foreach (char c in word1)
        {
            if (!freq1.ContainsKey(c))
                freq1[c] = 0;
            freq1[c]++;
        }

        
        foreach (char c in word2)
        {
            if (!freq2.ContainsKey(c))
                freq2[c] = 0;
            freq2[c]++;
        }

        int deletions = 0;

        
        foreach (var kv in freq1)
        {
            char ch = kv.Key;
            int count1 = kv.Value;
            int count2 = freq2.ContainsKey(ch) ? freq2[ch] : 0;

            deletions += Math.Abs(count1 - count2);
            if (freq2.ContainsKey(ch))
                freq2.Remove(ch);
        }

        
        foreach (var kv in freq2)
        {
            deletions += kv.Value;
        }

        Console.WriteLine(deletions);
    }
}
