using System;

class BankAccount
{
    public static void Run()
    {
        int balance = 10000;

        Console.WriteLine("Enter withdrawal amount:");

        try
        {
            if (!int.TryParse(Console.ReadLine(), out int amount))
            {
                throw new FormatException("Invalid input. Please enter a numeric value.");
            }

            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be greater than zero.");
            }

            if (amount > balance)
            {
                throw new InvalidOperationException("Insufficient balance.");
            }

            balance -= amount;
            Console.WriteLine($"Withdrawal successful. Remaining balance: {balance}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Transaction failed: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Transaction logged successfully.");
        }
    }
}
