namespace SmartBankingSystem
{
    public abstract class BankAccount
    {
        public string? AccountNumber { get; set; }
        public string? CustomerName { get; set; }
        public double Balance { get; set; }

        public List<string> TransactionHistory { get; set; } = new();

        public virtual void Deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidTransactionException("Invalid deposit amount");
            }

            Balance += amount;
            TransactionHistory.Add($"Deposited ₹{amount}");
            Console.WriteLine($"₹{amount} has been credited to your account..");

        }

        public virtual void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidTransactionException("Invalid withdrawal amount");
            }
            if (amount > Balance)
            {
                throw new InsufficientBalanceException("Balance not sufficient...");

            }
            Balance -= amount;
            TransactionHistory.Add($"Withdrawn ₹{amount}");
            Console.WriteLine($"₹{amount} has been debited from your account..");
        }

        public abstract double CalculateInterest();

        public void PrintTransactionHistory()
        {
            foreach (var txn in TransactionHistory)
                Console.WriteLine(txn);
        }
    }

}