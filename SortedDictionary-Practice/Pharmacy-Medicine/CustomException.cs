public class InvalidPriceException : Exception
{
    public InvalidPriceException(string msg): base(msg)
    {
        
    }
}

public class DuplicateMedicineException : Exception
{
    public DuplicateMedicineException(string msg): base(msg){ }
}

public class InvalidExpiryYearException : Exception
{
    public InvalidExpiryYearException(string msg) : base(msg){ }
}

public class MedicineNotFoundException : Exception
{
    public MedicineNotFoundException(string msg) : base(msg) { }
}


