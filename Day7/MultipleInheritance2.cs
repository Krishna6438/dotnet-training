
interface ISingingBird
{
    // Method to be implemented by any class that can sing
    public abstract void SingingQuality();
}

// Interface defining swimming + singing behavior
interface ISwimAndSingBird
{
    // Method to be implemented by any class that can swim and sing
    public abstract void SwimAndSingQualities();
}

// Bird Class implementing multiple interfaces (ISingingBird & ISwimAndSingBird)
class Bird : ISingingBird, ISwimAndSingBird
{
    // Implementation of ISingingBird interface method
    public void SingingQuality()
    {
        Console.WriteLine("Bird can sing only.");
    }

    // Implementation of ISwimAndSingBird interface method
    public void SwimAndSingQualities()
    {
        Console.WriteLine("Bird can sing and swim both.");
    }
}

// Driver class
// No Main() here to avoid multiple entry point error (Entry point -> program.cs)
class MultipleInheritance2
{
    // Run method will be called from Program.cs
    public static void Run()
    {
        // Creating object of Bird class
        Bird bird = new Bird();

        // Calling Singing behavior
        bird.SingingQuality();

        // Calling swimming + singing behavior
        bird.SwimAndSingQualities();
    }
}
