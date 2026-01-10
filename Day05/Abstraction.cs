using System;
namespace Abstraction;


abstract class Employee
{
    public abstract void TaxCollection();
}

class USEmployee : Employee
{
    public override void TaxCollection()
    {
        Console.WriteLine("US Employee....");
    }
}

class IndianEmployee : Employee
{
    public override void TaxCollection()
    {
        Console.WriteLine("Indian Employee....");
    }

}


abstract class Payment
{
    public decimal Amount{get;}
    protected Payment(decimal a)
    {
        Amount = a;
    }

    public void PaymentReceipt()
    {
        Console.WriteLine($"Receipt Amount: {Amount}");
    }

    public abstract void Pay();

}

class UPIPayment : Payment
{
    public string UpiId{get;}

    public UPIPayment(decimal amount , string id) : base(amount) //This calls the constructor of the parent class
    {
       // base.Amount = amount;  // if base class have parameterless constructor then it work
        UpiId = id;
    }

    public override void Pay()
    {
        Console.WriteLine($"Paid {Amount} via UPI ({UpiId}).");
    }

}

class AbstractionDemo
{
    public static void Run()
    {
        Employee emp1 = new USEmployee();
        Employee emp2 = new IndianEmployee();

        emp1.TaxCollection();
        emp2.TaxCollection();

        Payment p = new UPIPayment(499,"790603@bbl");
        p.Pay();
        p.PaymentReceipt();
    }
}