
// Relation between derived class and base class



public class Account
{
    public string Name { get; set; }
    public int AccountId { get; set; }

    public string GetAccountDetails()
    {
        return $"I am Base account . My Id is {AccountId}";
    }

}
public class SalesAccount : Account
{
    public string GetSalesAccountDetails()
    {
        string info = string.Empty;
        info += base.GetAccountDetails();
        info += "I am from Sales Derived class ";
        return info;
    }
    public string SalesInfo { get; set; }
}

public class PurchaseAccount : Account
{
    public string PurchaseInfo { get; set; }
}

public class CallAccount
{
    public static void Run()
    {
        Account account = new Account() { AccountId = 1, Name = "Account1" };
        string result = account.GetAccountDetails();
        Console.WriteLine(result);

        SalesAccount salesAccount = new SalesAccount() { AccountId = 1, Name = "Balu", SalesInfo = "" };
        var result1 = salesAccount.GetSalesAccountDetails();
        Console.WriteLine(result1);
    }
}


// Method Overriding
class Father{
    public virtual string InterestOn()
    {
        return "I like to play cricket";
    }
}

class Child : Father
{
    public override string InterestOn()
    {
        return "Mobile Games";
    }
}

class MethodOverriding
{
    public static void Run()
    {
        Father f1 = new Father();
        Console.WriteLine(f1.InterestOn());

        Father f2 = new Child(); // Polymorphism
        Console.WriteLine(f2.InterestOn());
    }
}