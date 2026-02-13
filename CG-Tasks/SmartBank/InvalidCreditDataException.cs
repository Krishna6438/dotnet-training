using System;

// Custom exception
public class InvalidCreditDataException : Exception
{
    public InvalidCreditDataException(string message) : base(message)
    {
        
    }
}