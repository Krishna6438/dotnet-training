namespace EmployeeManagementSystem
{
    public class Employee
    {
        public string EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Department { get; set; }
        public double Salary { get; set; }
        public DateTime JoiningDate { get; set; }
    }

    public class HRManager
    {
        private List<Employee> emp = new List<Employee>();
        private int idCounter = 1;
        public void AddEmployee(string name, string dept, double salary)
        {
            Employee e = new Employee()
            {
                EmployeeId = "E" + idCounter.ToString("D3"),
                Name = name,
                Department = dept,
                Salary = salary
            };
            idCounter++;
            emp.Add(e);

        }
        public SortedDictionary<string, List<Employee>> GroupEmployeesByDepartment()
        {
            SortedDictionary<string,List<Employee>> grouped = new SortedDictionary<string, List<Employee>>();
            foreach(var e in emp)
            {
                if (!grouped.ContainsKey(e.Department))
                {
                    grouped[e.Department] = new List<Employee>();
                }
                grouped[e.Department].Add(e);
            }
            return grouped;
        }

        public double CalculateDepartmentSalary(string department)
        {
            double totalSalary = 0;

            foreach(var e in emp)
            {
                if(e.Department.Equals(department, StringComparison.OrdinalIgnoreCase))
                {
                    totalSalary+= e.Salary;
                }
            }
            return totalSalary;
        }
        public List<Employee> GetEmployeesJoinedAfter(DateTime date)
        {
            return emp.Where(e=>e.JoiningDate>date).ToList();
        }

    }

    public class EmployeeManagement
    {
        public static void Run()
        {
            HRManager hr = new HRManager();

            // Add employees
            hr.AddEmployee("Krishna", "IT", 60000);
            hr.AddEmployee("Amit", "HR", 45000);
            hr.AddEmployee("Neha", "Sales", 50000);
            hr.AddEmployee("Riya", "IT", 70000);
            hr.AddEmployee("Arjun", "Sales", 55000);

            // Display employees grouped by department
            Console.WriteLine("👥 Employees Grouped by Department:\n");
            var groupedEmployees = hr.GroupEmployeesByDepartment();

            foreach (var dept in groupedEmployees)
            {
                Console.WriteLine($"Department: {dept.Key}");
                foreach (var emp in dept.Value)
                {
                    Console.WriteLine(
                        $"{emp.EmployeeId} | {emp.Name} | Salary: ₹{emp.Salary} | Joined: {emp.JoiningDate.ToShortDateString()}"
                    );
                }
                Console.WriteLine();
            }

            // Calculate total salary of IT department
            Console.WriteLine("💰 Total Salary of IT Department:");
            Console.WriteLine($"₹{hr.CalculateDepartmentSalary("IT")}\n");

            // Find employees who joined after a specific date
            DateTime filterDate = DateTime.Now.AddDays(-1);
            Console.WriteLine($"🆕 Employees Joined After {filterDate.ToShortDateString()}:\n");

            var recentEmployees = hr.GetEmployeesJoinedAfter(filterDate);
            foreach (var emp in recentEmployees)
            {
                Console.WriteLine($"{emp.EmployeeId} - {emp.Name} ({emp.Department})");
            }

            Console.WriteLine("\nProgram completed.");
        }
    }
}