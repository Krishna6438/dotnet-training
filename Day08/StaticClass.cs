using System.Dynamic;

static class GeneralUses
{
    // Static variable
    // Only ONE copy exists for the entire application
    public static  int Roll;

// Static constructor
    // 1. Called automatically
    // 2. Called ONLY ONCE
    // 3. Used to initialize static data
    // 4. Cannot be called explicitly
    // 5. Has no access modifier
    
    static GeneralUses(){
        Roll = 1;
    }

    // Static method
    // Can access only static members
    // Can be called using class name
    public static void GetRoll()
    {
        Console.WriteLine(Roll);
    }
}

public class StaticClassExample
{
    public static void Run()
    {
         // First call
        // Static constructor is invoked here
        GeneralUses.GetRoll();
        GeneralUses.GetRoll(); // this time constructor is not called
    }
}