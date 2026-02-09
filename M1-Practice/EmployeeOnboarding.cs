namespace M1Practice
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }

        public Employee(int id, string name, string email, double salary)
        {
            Id = id;
            Name = name;

            Email = email.Contains("@") ? email : "unknown@company.com";
            Salary = salary > 0 ? salary : 30000;
        }

        public void Display()
        {
            Console.WriteLine($"Id: {Id}, Name: {Name}, Email: {Email}, Salary: {Salary}");
        }
    }

    public class EmployeeOnboarding
    {
        public static void Run()
        {
            Employee e1 = new Employee(1, "Krishna", "krishna@gmail.com", 50000);
            Employee e2 = new Employee(2, "Amit", "amitgmail.com", 15000);
            Employee e3 = new Employee(3, "Riya", "riya@company.com", 0);

            e1.Display();
            e2.Display();
            e3.Display();
        }
    }
}
