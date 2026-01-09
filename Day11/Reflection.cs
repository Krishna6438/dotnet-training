using System;
using System.Reflection;


public class Department
{
    
}

public class ReflectionExample
{
    public static void Run()
    {
        Department obj = new Department();
        var props = obj.GetType().GetFields(BindingFlags.NonPublic|BindingFlags.Instance).ToList();

        foreach(var prop in props)
        {
            Console.WriteLine(prop.Name);
        }
        Console.ReadLine();
    }
}

