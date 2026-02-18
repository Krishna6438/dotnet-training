namespace SmartBankingSystem
{
    public class BankManager
    {
        private List<BankAccount> _list = new List<BankAccount>();

        public void AddAccount(BankAccount account)
        {
            _list.Add(account);
        }

        public List<BankAccount> GetAccountsWithBalanceAbove50000()
        {
            return _list.Where(b => b.Balance > 50000).ToList();
        }

        public double GetTotalBankBalance()
        {
            return _list.Sum(b => b.Balance);
        }
        public List<BankAccount> GetTopThreeAccounts()
        {
            return _list.OrderByDescending(b => b.Balance).Take(3).ToList();
        }

        


        public void Transfer(string fromAcc, string toAcc, double amount)
        {
            var sender = _list.FirstOrDefault(a => a.AccountNumber == fromAcc);
            var receiver = _list.FirstOrDefault(a => a.AccountNumber == toAcc);

            if (sender == null || receiver == null)
                throw new InvalidTransactionException("Invalid account");

            sender.Withdraw(amount);
            receiver.Deposit(amount);

            sender.TransactionHistory.Add($"Transferred ₹{amount} to {receiver.AccountNumber}");
            receiver.TransactionHistory.Add($"Received ₹{amount} from {sender.AccountNumber}");
        }

        public void GroupAccountsByType()
        {
            var groups = _list.GroupBy(a => a.GetType().Name);

            foreach (var group in groups)
            {
                Console.WriteLine($"\n{group.Key} Accounts:");

                foreach (var acc in group)
                {
                    Console.WriteLine($"{acc.CustomerName} - ₹{acc.Balance}");
                }
            }
        }

        public List<BankAccount> GetCustomersStartingWithR()
        {
            return _list
                .Where(a => a.CustomerName != null && a.CustomerName.StartsWith("R"))
                .ToList();
        }

    }
}