public class StudentUtility
{
    SortedDictionary<double, List<Student6>> manage = new SortedDictionary<double, List<Student6>>();

    public void AddStudent(Student6 student)
    {
        if (student.Gpa < 0 || student.Gpa > 10)
        {
            throw new InvalidGPAException("Invalid GPA");
        }

        foreach (var kvp in manage.Values)
        {
            if (kvp.Any(s => s.Id == student.Id))
            {
                throw new DuplicateStudentException("Student Already exists.");
            }
        }

        if (!manage.ContainsKey(student.Gpa))
            manage[student.Gpa] = new List<Student6>();

        manage[student.Gpa].Add(student);
    }

    //  Ranking by GPA DESCENDING 
    public void GetAllStudents()
    {
        
        var students = manage.Values
                            .SelectMany(list=>list)
                            .OrderByDescending(s=>s.Gpa);

        foreach (var s in students)
        {
            Console.WriteLine($"Details: {s.Id} {s.Name} {s.Gpa}");
        }
    }

    public void UpdateGPA(string id, double newGpa)
    {
        foreach (var s in manage.Values)
        {
            var stu = s.FirstOrDefault(s => s.Id == id);
            if (stu != null)
            {
                stu.Gpa = newGpa;
                return;
            }

        }
        throw new StudentNotFoundException("Student Not found");
    }

    public static void Run()
    {
        StudentUtility utility = new StudentUtility();
        while (true)
        {
            Console.WriteLine("1 → Display Ranking");
            Console.WriteLine("2 → Update GPA");
            Console.WriteLine("3 → Add Student");
            Console.WriteLine("4 → Exit");


            try
            {
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        utility.GetAllStudents();
                        break;

                    case 2:
                        Console.WriteLine("Enter Id: ");
                        string? id = Console.ReadLine();
                        Console.WriteLine("Enter Updated GPA:");
                        double gpa = double.Parse(Console.ReadLine());
                        utility.UpdateGPA(id, gpa);
                        Console.WriteLine("GPA Updated...");
                        break;

                    case 3:
                        Console.WriteLine("Enter Id Name GPA");
                        var input = Console.ReadLine().Split();
                        Student6 student = new Student6(
                            input[0],
                            input[1],
                            double.Parse(input[2])
                        );

                        utility.AddStudent(student);
                        Console.WriteLine("Student Added Successfully...");
                        break;

                    case 4:
                        return;
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
    }
}