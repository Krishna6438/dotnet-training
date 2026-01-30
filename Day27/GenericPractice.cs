using Microsoft.VisualBasic;

public class Student4
{
    public string? Name { get; set; }
    public int Id { get; set; }
    public int Marks1 { get; set; }
    public int Marks2 { get; set; }

    public delegate void Notify(Student4 student);

    
    public Notify? NotifyResult;
    
    public double AverageMarks
    {
        get { return (Marks1 + Marks2) / 2.0; }
    }

    public void CheckPassOrFail()
    {
        if(AverageMarks < 33)
        {
            NotifyResult?.Invoke(this);
        }
    }
}

public class ExecuteStudent
{

    public static void Run()
    {
        List<Student4> s = new List<Student4>
        {
            new Student4 { Id = 1, Name = "Kajal", Marks1 = 85, Marks2 = 90 },
            new Student4 { Id = 2, Name = "Aman",Marks1 = 78, Marks2 = 88 },
            new Student4 { Id = 3, Name = "Riya", Marks1 = 92, Marks2 = 95 },
            new Student4 { Id = 4, Name = "Neha", Marks1 = 80, Marks2 = 82 },
            new Student4 { Id = 5, Name = "Rahul", Marks1 = 88, Marks2 = 84 },
            new Student4 { Id = 6, Name = "Sahil", Marks1 = 91, Marks2 = 89 },
            new Student4{ Id = 7, Name = "Ankit", Marks1 = 76, Marks2 = 79 },
            new Student4{Id = 8, Name = "Robin", Marks1 = 28, Marks2 = 30}
        };

        

        var top5 = s.OrderByDescending(s => s.AverageMarks).Take(5);

        Console.WriteLine("Top 5 students: ");

        foreach (var student in top5)
        {
            Console.WriteLine(
                $"ID: {student.Id}, Name: {student.Name}, " +
                $"Avg Marks: {student.AverageMarks}"
            );
        }

        foreach (var student in s)
        {
            student.NotifyResult += NotifyFail;
            student.CheckPassOrFail();
        }

        static void NotifyFail(Student4 student)
        {
            Console.WriteLine(
                $"FAILED → ID: {student.Id}, Name: {student.Name}, Avg: {student.AverageMarks} -> Need to give Reappear"
            );
        }
    }


}