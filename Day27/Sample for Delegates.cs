using System;
using System.Collections.Generic;

public class Student5
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Marks { get; set; }
}

public class ExecuteDelegates
{
    public static void Run()
    {
        List<Student5> students = new List<Student5>
        {
            new Student5 { Id = 1, Name = "Aman", Marks = 72 },
            new Student5 { Id = 2, Name = "Riya", Marks = 35 },
            new Student5 { Id = 3, Name = "Kajal", Marks = 91 },
            new Student5 { Id = 4, Name = "Neha", Marks = 28 }
        };

        
        Predicate<Student5> isFailed = s => s.Marks < 40;

        
        Action<Student5> notifyFail = s =>
        {
            Console.WriteLine($"FAILED: {s.Name} (Marks: {s.Marks})");
        };

        
        Func<Student5, (string Grade, string Remark)> evaluateStudent = s =>
        {
            if (s.Marks >= 90) return ("A+", "Excellent");
            if (s.Marks >= 75) return ("A", "Very Good");
            if (s.Marks >= 60) return ("B", "Good");
            if (s.Marks >= 40) return ("C", "Needs Improvement");
            return ("F", "Fail");
        };

        foreach (var student in students)
        {
            var result = evaluateStudent(student);   

            if (result.Grade == "F")
            {
                notifyFail(student);
            }
            else
            {
                Console.WriteLine(
                    $"{student.Name} → Grade: {result.Grade}, Remark: {result.Remark}"
                );
            }
        }
    }
}
