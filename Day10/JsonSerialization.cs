using System.Text.Json;
public class Person1
{
    public string? Name{get; set;}
    public int Age{get; set;}
}

public class JsonSerialization
{
    public static void Run()
    {
        Person1 p = new Person1
        {
            Name = "Ayush",
            Age = 25
        };

        // Serializing the Person1 object into JSON string
        // Converts object → JSON format
        string jsonString = JsonSerializer.Serialize(p);

        Console.WriteLine(jsonString);
    }

}