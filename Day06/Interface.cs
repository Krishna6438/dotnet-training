using System;

// An interface is a contract that defines a set of methods, properties, or events without providing their implementation. Any class that implements the interface must provide implementations for all its members.

// Interface ref = new Class(); // ✅
// Class obj = new Interface(); // ❌

public interface Print
{
    // public void Display(). // Interface is abstract by default
    // {
    //     Console.WriteLine("It is Interface");
    // }

    public void Display();
}

class InterfaceClass : Print
{
    public void Display()
    {
        Console.WriteLine("It is Interface");
    }
    public static void Run()
    {
        Print p = new InterfaceClass();
        p.Display();
    }    
}