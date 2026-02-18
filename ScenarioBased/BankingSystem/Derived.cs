using System.Runtime.CompilerServices;

namespace SmartBankingSystem
{
    public class SavingAccount : BankAccount
    {
        private const double MIN_BALANCE = 1000;
        public override void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new InvalidTransactionException("Invalid withdrawal amount");
            if (Balance - amount < MIN_BALANCE)
            {
                throw new MinimumBalanceException("Minimum amount violation..");
            }
            base.Withdraw(amount);
        }

        public override double CalculateInterest()
        {
            return Balance * 0.04; // 4%
        }
    }

    public class CurrentAccount : BankAccount
    {
        public double OverdraftLimit { get; set; } = 10000;

        public override void Withdraw(double amount)
        {
            if (amount > Balance + OverdraftLimit)
                throw new InsufficientBalanceException("Overdraft limit exceeded");

            Balance -= amount;
            TransactionHistory.Add($"Withdrawn ₹{amount}");

            Console.WriteLine($"₹{amount} debited.");
        }

        public override double CalculateInterest()
        {
            return 0;   // No interest
        }
    }

    public class LoanAccount : BankAccount
    {
        public override void Deposit(double amount)
        {
            throw new InvalidTransactionException("Loan account cannot accept deposits");
        }

        public override double CalculateInterest()
        {
            return Math.Abs(Balance) * 0.08;   // 8% interest
        }
    }

}