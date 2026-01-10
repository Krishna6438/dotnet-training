/*
    CONS / DESIGN PROBLEMS OF THIS APPROACH

1. Breaks Polymorphism
    - Behavior is decided using 'if (p is Man / Woman)'
    - Instead of letting the object decide its own behavior

2. Base Class Depends on Derived Classes
    - Person knows about Man and Woman
    - This creates tight coupling
    - Base class should NEVER depend on child classes

3. Violates Open/Closed Principle
    - If a new class (e.g., Child : Person) is added,
    - this method must be modified again

4. Requires Explicit Type Checking and Casting
    - Uses 'is' operator and downcasting
    - Increases code complexity and risk of errors

5. Not Scalable
    - More derived classes → more if-else blocks
    - Code becomes hard to maintain

6. Hard to Test
    - Logic for multiple types is mixed in one method
    - Unit testing becomes complicated

7. Poor Object-Oriented Design
    - Inheritance is used, but polymorphism is NOT
    - Defeats the purpose of OOP

8. Interview Red Flag
    - Works functionally, but considered bad design
    - Interviewers expect virtual/override instead

SUMMARY:
    "This approach works, but it is NOT proper OOP design
    and should be avoided in real applications."
*/


class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    // Person(int id , string name , int age){
    //         Id = id;
    //         Name = name;
    //         Age = age;
    //     }

    public void GetPersonDetail(Person p)
    {
        //Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Age: {p.Age}");
        string result = "";



        if (p is Man)
        {
            Man man = (Man)p;
            result = $"Id = {man.Id} Name = {man.Name} Age = {man.Age} PlayGame = {man.PlayGame} ";
        }

        if (p is Woman)
        {
            Woman woman = (Woman)p;
            result = $"Id = {woman.Id} Name = {woman.Name} Age = {woman.Age} PlayAndManage = {woman.PlayAndManage} ";

        }

        Console.WriteLine(result);


    }
}

class Man : Person
{

    public string PlayGame { get; set; }

    public void GetManDetail(Man input)
    {
        Console.WriteLine($"Plays Game: {input.PlayGame}");
    }
}

class Woman : Person
{
    public bool PlayAndManage { get; set; }

    public void GetWomanDetail(Woman input)
    {
        Console.WriteLine($"Can Play & Manage: {input.PlayAndManage}");
    }
}


class Inheritance
{
    public static void Run()
    {
        Man m = new Man
        {
            Id = 1,
            Name = "Ayush",
            Age = 20,
            PlayGame = "Cricket"
        };

        Woman w = new Woman
        {
            Id = 2,
            Name = "Anita",
            Age = 21,
            PlayAndManage = true
        };

        m.GetPersonDetail(m);
        w.GetPersonDetail(w);

    }
}