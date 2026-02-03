using System;

class BonusCalculator
{
    public static void Run()
    {
        int[] salaries = { 5000, 0, 7000 };
        int bonus = 10000;

        for (int i = 0; i < salaries.Length; i++)
        {
            try
            {
                int bonusShare = bonus / salaries[i];
                Console.WriteLine($"Employee {i + 1}: Bonus Share = {bonusShare}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine($"Employee {i + 1}: Salary is zero, bonus cannot be calculated.");
            }
        }

        Console.WriteLine("Bonus calculation completed for all employees.");
    }
}
