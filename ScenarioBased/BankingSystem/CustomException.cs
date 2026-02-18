namespace SmartBankingSystem
{
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string msg) : base(msg){}
    }

    public class MinimumBalanceException : Exception
    {
        public MinimumBalanceException(string msg) : base(msg){}
    }

    public class InvalidTransactionException : Exception
    {
        public InvalidTransactionException(string msg) : base(msg){}
    }


}