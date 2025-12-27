using System.Dynamic;

namespace ExaminationExample ;
// Base class for HOD and Examiner
class Employee
{
    public int EmployeeId{get; set;}
    public string EmployeeName{get;set;}
    public int DepartmentId{get; set;}
}

class HOD : Employee
{
    public string Responsibility{get; set;}
}

class Examiner : Employee
{
    public bool IsExternal{get; set;}
}
// Department of HOD and Examiner
class Department
{
    public int DepartmentId{get; set;}
    public string DepartmentName{get; set;}
}

// Semester of Students whose exam we have to schedule
class Semester
{
    public int SemesterId{get; set;}
    public int SemesterNumber{get; set;}
}

class Subject
{
    public int SubjectId { get; set; }
    public string SubjectName { get; set; }
}
class Batch
{
    public int BatchId { get; set; }
    public string BatchName { get; set; }

        // Students
    public Student Student1;
    public Student Student2;
    public Student Student3;

    public Student Student4;
    public Student Student5;
    
}

class Student
{
    public int StudentId{get; set;}
    public string StudentName{get; set;}
    public int SemesterId{get; set;}
}

class Exam
{
    public int ExamId { get; set; }
    public string Subject { get; set; }
    public DateTime ExamDate { get; set; }
    public TimeSpan ExamTime { get; set; }

    public int SemesterId { get; set; }
    public int DepartmentId { get; set; }

    public int CreatedByHodId { get; set; }
}

public class ExaminerAssignment
{
    public int AssignmentId { get; set; }
    public int ExamId { get; set; }
    public int ExaminerId { get; set; }
    
}

class Room
{
    public int RoomId{get; set;}
    public int Capacity{get;set;}
    public string RoomNo{get; set;}
}



    class ExaminationExampleClass
{
    public static void Run()
    {
        // Department
        Department dept = new Department
        {
            DepartmentId = 1,
            DepartmentName = "Computer Science"
        };

        // HOD
        HOD hod = new HOD
        {
            EmployeeId = 101,
            EmployeeName = "Dr. Sharma",
            DepartmentId = dept.DepartmentId,
            Responsibility = "Exam Scheduling"
        };

        // Examiner
        Examiner examiner = new Examiner
        {
            EmployeeId = 201,
            EmployeeName = "Mr. Verma",
            DepartmentId = dept.DepartmentId,
            IsExternal = true
        };

        // Semester
        Semester semester = new Semester
        {
            SemesterId = 1,
            SemesterNumber = 6
        };

        // Batch with students
        Batch batch = new Batch
        {
            BatchId = 1,
            BatchName = "Batch-A",

            Student1 = new Student { StudentId = 1, StudentName = "Student-1", SemesterId = semester.SemesterId },
            Student2 = new Student { StudentId = 2, StudentName = "Student-2", SemesterId = semester.SemesterId },
            Student3 = new Student { StudentId = 3, StudentName = "Student-3", SemesterId = semester.SemesterId },
            Student4 = new Student { StudentId = 4, StudentName = "Student-4", SemesterId = semester.SemesterId },
            Student5 = new Student { StudentId = 5, StudentName = "Student-5", SemesterId = semester.SemesterId }
        };

        // Exam
        Exam exam = new Exam
        {
            ExamId = 1001,
            Subject = "OOPS with C#",
            ExamDate = new DateTime(2025, 4, 10),
            ExamTime = new TimeSpan(10, 0, 0),
            SemesterId = semester.SemesterId,
            DepartmentId = dept.DepartmentId,
            CreatedByHodId = hod.EmployeeId
        };

        // Examiner Assignment
        ExaminerAssignment assignment = new ExaminerAssignment
        {
            AssignmentId = 1,
            ExamId = exam.ExamId,
            ExaminerId = examiner.EmployeeId
        };

        // Room
        Room room = new Room
        {
            RoomId = 1,
            RoomNo = "B-204",
            Capacity = 60
        };

        // ---------------- OUTPUT ----------------
        Console.WriteLine("=== Examination Details ===");
        Console.WriteLine($"Department     : {dept.DepartmentName}");
        Console.WriteLine($"HOD            : {hod.EmployeeName}");
        Console.WriteLine($"Exam Subject   : {exam.Subject}");
        Console.WriteLine($"Exam Date      : {exam.ExamDate.ToShortDateString()}");
        Console.WriteLine($"Exam Time      : {exam.ExamTime}");
        Console.WriteLine($"Examiner       : {examiner.EmployeeName} (External: {examiner.IsExternal})");
        Console.WriteLine($"Room           : {room.RoomNo} (Capacity: {room.Capacity})");
        Console.WriteLine($"Batch          : {batch.BatchName}");
    }
}





