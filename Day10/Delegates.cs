using System;

// Step 1: Declare a delegate
// Delegate can point to any method that takes two int parameters
// and returns an int
public delegate int DelegateAddFunctionName(int a, int b);

public class ExampleOfDelegate
{
    // Method 1
    public int AddMethod3(int a, int b)
    {
        return a + b + 40;
    }

    // Method 2
    public int AddMethod2(int a, int b)
    {
        return a + b + 10;
    }

    // Method demonstrating delegate usage
    public void DelegateEx1()
    {
        // Delegate pointing to AddMethod3
        DelegateAddFunctionName delegateVariable = AddMethod3;

        int result1 = delegateVariable(1, 2);
        Console.WriteLine("Result from AddMethod3: " + result1);

        // Changing delegate to point to another method
        delegateVariable = AddMethod2;

        int result2 = delegateVariable(1, 2);
        Console.WriteLine("Result from AddMethod2: " + result2);
    }
}

public class Delegates
{
    public static void Run()
    {
        // Creating object of ExampleOfDelegate
        ExampleOfDelegate example = new ExampleOfDelegate();

        // Calling delegate example method
        example.DelegateEx1();
    }
}
