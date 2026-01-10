// OOPS Concept -> Overloading of Constructor && Changing Namespace

/*
Why Do We Need Constructor Overloading?

To create objects with different sets of data

To provide flexibility in object creation

To avoid writing multiple initialization methods

To support default and customized initialization

*/
class Visitor
{
    public int Id { set; get; }
    public string Name { get; set; }
    public string Requirement { get; set; }

    public string LogHistory{get;}

    public Visitor()
    {
        
    }

    public Visitor(int id)
    {
        this.Id = id;
    }

    public Visitor(int id, string name)
    {
        if (name.Contains("Idiot", StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException("Invalid name: contains prohibited word.");
        }
        this.Id = id;
        this.Name = name;
    }

    public Visitor(int id, string name, string requirement)
    {
        this.Id = id;
        this.Name = name;
        this.Requirement = requirement;
    }

    public void Display()
    {
        Console.WriteLine($"Id: {Id}, Name: {Name}, Requirement: {Requirement}");
    }
}


// Exception handling
public class MainConstructor
{
    public static void Run()
    {
        Visitor dd = new Visitor();

        try
        {
            Visitor visitor = new Visitor(10, "Ravi Idiot");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: "+ex.Message);
        }

        Visitor v2 = new Visitor(11, "Amit", "Meeting");
        v2.Display();
    }
}

// Take input of two number and do addition with the help of constructor


class Addition
{
    public int Num1 {get; set;}
    public int Num2 {get; set;}

    public int sum {get;} // only get not 

    Addition(int a , int b)
    {
        this.Num1 = a;
        this.Num2 = b;
        sum = Num1 + Num2; // but only in constructor we can set the value to (getOnly) property

    }

    void Display()
    {
        Console.WriteLine($"Addition of {Num1} + {Num2} = {sum}");
    }

    public static void Run()
    {
        Addition ad = new Addition(5,6);
        ad.Display();
    }
}


// For Home -> use only set property 

// Constructor Inheritance

//static constructor

// Field -> private and important variable for the class we can't access from outside the class


// Call Field

// using getter and setter validate the value and store it in the field  

//




class Employee
{
    // Private fields
    private int id;
    private string name;
    private double salary;

    private string Errors="";

    // Public property for Id
    public int Id
    {
        get { return id; }
        set
        {
            if (value > 0)
                id = value;
            else
            {
                Errors+= "Invalid Id! Id must be greater than 0."+ Environment.NewLine;
                // Console.WriteLine("Invalid Id! Id must be greater than 0.");
            }
        }
    }

    // Public property for Name
    public string Name
    {
        get { return name; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                name = value;
            else
                Errors+="Invalid Name! Name cannot be empty."+Environment.NewLine;
                // Console.WriteLine("Invalid Name! Name cannot be empty.");
        }
    }

    // Public property for Salary
    public double Salary
    {
        get { return salary; }
        set
        {
            if (value >= 0)
                salary = value;
            else
                Errors+="Invalid Salary! Salary cannot be negative."+Environment.NewLine;
                // Console.WriteLine("Invalid Salary! Salary cannot be negative.");
        }
    }

    // Display method
    public void Display()
    {
        Console.WriteLine("\n--- Employee Details ---");
        Console.WriteLine("Employee Id    : " + Id);
        Console.WriteLine("Employee Name  : " + Name);
        Console.WriteLine("Employee Salary: " + Salary);
    }

    public string GetErrors()
    {
        return Errors;
    }
}

class FieldsCheck
{
    public static void Run()
    {
        Employee emp = new Employee();

        // Taking input from user
        Console.Write("Enter Employee Id: ");
        emp.Id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Employee Name: ");
        emp.Name = Console.ReadLine();

        Console.Write("Enter Employee Salary: ");
        emp.Salary = Convert.ToDouble(Console.ReadLine());

        if (!string.IsNullOrEmpty(emp.GetErrors()))
        {
            Console.WriteLine("\n--- Validation Errors ---");
            Console.WriteLine(emp.GetErrors());
        }
        else
        {
            emp.Display();
        }
    }
}