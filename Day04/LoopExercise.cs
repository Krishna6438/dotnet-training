using System;
using System.Numerics; // Used for large factorial values

class LoopExercise
{
    // 1. Fibonacci Series
    static void Fibonacci()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());

        int a = 0, b = 1;

        // Print first two Fibonacci numbers
        Console.Write(a + " " + b + " ");

        // Generate remaining numbers
        for (int i = 3; i <= n; i++)
        {
            int c = a + b;
            Console.Write(c + " ");
            a = b;
            b = c;
        }
        Console.WriteLine();
    }

    // 2. Prime Number Check function
    static void PrimeCheck()
    {
        Console.Write("Enter number: ");
        int n = int.Parse(Console.ReadLine());
        bool isPrime = true;

        if (n <= 1)
            isPrime = false;
        else
        {
            // Check divisibility (basic rule of prime number)
            for (int i = 2; i <= n / 2; i++)
            {
                if (n % i == 0)
                {
                    isPrime = false;
                    break; // exit loop if divisor found (Not a Prime number)
                }
            }
        }

        Console.WriteLine(isPrime ? "Prime Number" : "Not Prime");
    }

    // 3. Armstrong Number
    static void Armstrong()
    {
        Console.Write("Enter number: ");
        int n = int.Parse(Console.ReadLine());

        int temp = n, sum = 0;
        int digits = n.ToString().Length;

        // Calculate sum of digits raised to power of digits
        while (temp > 0)
        {
            int d = temp % 10;
            sum += (int)Math.Pow(d, digits);
            temp /= 10;
        }

        Console.WriteLine(sum == n ? "Armstrong Number" : "Not Armstrong");
    }

    // 4. Reverse & Palindrome
    static void ReversePalindrome()
    {
        Console.Write("Enter number: ");
        int n = int.Parse(Console.ReadLine());

        int temp = n, rev = 0;

        // Reverse the number
        while (temp > 0)
        {
            rev = rev * 10 + temp % 10;
            temp /= 10;
        }

        Console.WriteLine("Reverse: " + rev);
        Console.WriteLine(n == rev ? "Palindrome" : "Not Palindrome");
    }

    // 5. GCD & LCM
    static void GcdLcm()
    {
        Console.Write("Enter first number: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        int b = int.Parse(Console.ReadLine());

        int x = a, y = b;

        // Euclidean Algorithm for GCD
        while (y != 0)
        {
            int r = x % y;
            x = y;
            y = r;
        }

        int gcd = x;
        int lcm = (a * b) / gcd;

        Console.WriteLine("GCD = " + gcd);
        Console.WriteLine("LCM = " + lcm);
    }

    // 6. Pascal's Triangle
    static void PascalTriangle()
    {
        Console.Write("Enter rows: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int val = 1;
            for (int j = 0; j <= i; j++)
            {
                Console.Write(val + " ");
                val = val * (i - j) / (j + 1);
            }
            Console.WriteLine();
        }
    }

    // 7. Binary to Decimal Conversion
    static void BinaryToDecimal()
    {
        Console.Write("Enter binary number: ");
        string bin = Console.ReadLine();

        int dec = 0, power = 1;

        // Convert binary to decimal manually
        for (int i = bin.Length - 1; i >= 0; i--)
        {
            if (bin[i] == '1')
                dec += power;
            power *= 2;
        }

        Console.WriteLine("Decimal = " + dec);
    }

    // 8. Diamond Pattern
    static void Diamond()
    {
        Console.Write("Enter rows: ");
        int n = int.Parse(Console.ReadLine());

        // Upper half
        for (int i = 1; i <= n; i++)
        {
            for (int s = i; s < n; s++) Console.Write(" ");
            for (int j = 1; j <= 2 * i - 1; j++) Console.Write("*");
            Console.WriteLine();
        }

        // Lower half
        for (int i = n - 1; i >= 1; i--)
        {
            for (int s = n; s > i; s--) Console.Write(" ");
            for (int j = 1; j <= 2 * i - 1; j++) Console.Write("*");
            Console.WriteLine();
        }
    }

    // 9. Factorial using BigInteger
    static void LargeFactorial()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());

        BigInteger fact = 1;

        for (int i = 1; i <= n; i++)
            fact *= i;

        Console.WriteLine("Factorial = " + fact);
    }

    // 10. Guessing Game (do-while)
    static void GuessGame()
    {
        int secret = 7;
        int guess;

        do
        {
            Console.Write("Guess the number: ");
            guess = int.Parse(Console.ReadLine());

            if (guess != secret)
                Console.WriteLine("Wrong! Try again.");
        }
        while (guess != secret);

        Console.WriteLine("Correct! You won ");
    }

    // 11. Digital Root
    static void DigitalRoot()
    {
        Console.Write("Enter number: ");
        int n = int.Parse(Console.ReadLine());

        // Repeat until single digit
        while (n >= 10)
        {
            int sum = 0;
            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }
            n = sum;
        }

        Console.WriteLine("Digital Root = " + n);
    }

    // 12. Continue Example
    static void SkipMultiplesOf3()
    {
        for (int i = 1; i <= 50; i++)
        {
            if (i % 3 == 0)
                continue; // skip multiples of 3

            Console.Write(i + " ");
        }
        Console.WriteLine();
    }

    // 13. Strong Number
    static void StrongNumber()
    {
        Console.Write("Enter number: ");
        int n = int.Parse(Console.ReadLine());

        int temp = n, sum = 0;

        while (temp > 0)
        {
            int d = temp % 10;
            int fact = 1;

            for (int i = 1; i <= d; i++)
                fact *= i;

            sum += fact;
            temp /= 10;
        }

        Console.WriteLine(sum == n ? "Strong Number" : "Not Strong Number");
    }

    // 14. Goto Search Example
    static void GotoSearch()
    {
        int target = 5;
        bool found = false;

        for (int i = 1; i <= 3; i++)
        {
            for (int j = 1; j <= 3; j++)
            {
                for (int k = 1; k <= 5; k++)
                {
                    if (k == target)
                    {
                        found = true;
                        goto FOUND; // exit all loops
                    }
                }
            }
        }

    FOUND:
        Console.WriteLine(found ? "Target Found using goto" : "Target Not Found");
    }

    // MAIN MENU
    public static void Run()
    {
        Console.WriteLine("\n--- LOOP EXERCISES MENU ---");
        Console.WriteLine("1. Fibonacci");
        Console.WriteLine("2. Prime Check");
        Console.WriteLine("3. Armstrong");
        Console.WriteLine("4. Reverse & Palindrome");
        Console.WriteLine("5. GCD & LCM");
        Console.WriteLine("6. Pascal Triangle");
        Console.WriteLine("7. Binary to Decimal");
        Console.WriteLine("8. Diamond Pattern");
        Console.WriteLine("9. Large Factorial");
        Console.WriteLine("10. Guessing Game");
        Console.WriteLine("11. Digital Root");
        Console.WriteLine("12. Continue Example");
        Console.WriteLine("13. Strong Number");
        Console.WriteLine("14. Goto Search");

        Console.Write("\nChoose option: ");
        int ch = int.Parse(Console.ReadLine());

        switch (ch)
        {
            case 1: Fibonacci(); break;
            case 2: PrimeCheck(); break;
            case 3: Armstrong(); break;
            case 4: ReversePalindrome(); break;
            case 5: GcdLcm(); break;
            case 6: PascalTriangle(); break;
            case 7: BinaryToDecimal(); break;
            case 8: Diamond(); break;
            case 9: LargeFactorial(); break;
            case 10: GuessGame(); break;
            case 11: DigitalRoot(); break;
            case 12: SkipMultiplesOf3(); break;
            case 13: StrongNumber(); break;
            case 14: GotoSearch(); break;
            default: Console.WriteLine("Invalid Choice"); break;
        }
    }
}
