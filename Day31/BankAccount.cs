
public class BankAccountTest
{
    public int Balance { get; private set; }

    public BankAccountTest(int initialBalance)
    {
        Balance = initialBalance;
    }

    public void Deposit(int amount)
    {
        if (amount < 0)
            throw new Exception("Deposit amount cannot be negative");

        Balance += amount;
    }

    public void Withdraw(int amount)
    {
        if (amount > Balance)
            throw new Exception("Insufficient funds.");

        Balance -= amount;
    }
    public static void Run()
    {
        BankAccountTest account = new BankAccountTest(1000);

        account.Deposit(500);
        account.Withdraw(200);

        Console.WriteLine("Final Balance: " + account.Balance);
    }
}



