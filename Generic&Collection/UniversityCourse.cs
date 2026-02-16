using System;
using System.Collections.Generic;
using System.Linq;

//
// Base constraints
//
public interface IStudent
{
    int StudentId { get; }
    string Name { get; }
    int Semester { get; }
}

public interface ICourse
{
    string CourseCode { get; }
    string Title { get; }
    int MaxCapacity { get; }
    int Credits { get; }
}

//
// Generic Enrollment System
//
public class EnrollmentSystem<TStudent, TCourse>
    where TStudent : IStudent
    where TCourse : ICourse
{
    private Dictionary<TCourse, List<TStudent>> _enrollments = new();

    public bool EnrollStudent(TStudent student, TCourse course)
    {
        // Create list ONLY if course not present
        if (!_enrollments.ContainsKey(course))
        {
            _enrollments[course] = new List<TStudent>();
        }

        var students = _enrollments[course];

        // Capacity check
        if (students.Count >= course.MaxCapacity)
            return false;

        // Prerequisite check
        if (course is LabCourse labCourse)
        {
            if (student.Semester < labCourse.RequiredSemester)
                return false;
        }

        // Duplicate check
        if (students.Any(s => s.StudentId == student.StudentId))
            return false;

        students.Add(student);
        return true;
    }

    public IReadOnlyList<TStudent> GetEnrolledStudents(TCourse course)
    {
        if (_enrollments.TryGetValue(course, out var students))
        {
            return students.AsReadOnly();
        }

        return new List<TStudent>().AsReadOnly();
    }

    public IEnumerable<TCourse> GetStudentCourses(TStudent student)
    {
        return _enrollments
            .Where(e => e.Value.Any(s => s.StudentId == student.StudentId))
            .Select(e => e.Key);
    }

    public int CalculateStudentWorkload(TStudent student)
    {
        return GetStudentCourses(student)
            .Sum(c => c.Credits);
    }
}

//
// Specialized Student
//
public class EngineeringStudent : IStudent
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public int Semester { get; set; }
    public string Specialization { get; set; }
}

//
// Specialized Course
//
public class LabCourse : ICourse
{
    public string CourseCode { get; set; }
    public string Title { get; set; }
    public int MaxCapacity { get; set; }
    public int Credits { get; set; }
    public string LabEquipment { get; set; }
    public int RequiredSemester { get; set; }
}

//
// Generic GradeBook
//
public class GradeBook<TStudent, TCourse>
    where TStudent : IStudent
    where TCourse : ICourse
{
    private Dictionary<(TStudent, TCourse), double> _grades = new();
    private EnrollmentSystem<TStudent, TCourse> _enrollmentSystem;

    public GradeBook(EnrollmentSystem<TStudent, TCourse> enrollmentSystem)
    {
        _enrollmentSystem = enrollmentSystem;
    }

    public void AddGrade(TStudent student, TCourse course, double grade)
    {
        if (grade < 0 || grade > 100)
            throw new ArgumentException("Grade must be between 0 and 100");

        var isEnrolled = _enrollmentSystem
            .GetEnrolledStudents(course)
            .Any(s => s.StudentId == student.StudentId);

        if (!isEnrolled)
            throw new InvalidOperationException("Student not enrolled in course");

        _grades[(student, course)] = grade;
    }

    public double? CalculateGPA(TStudent student)
    {
        var studentGrades = _grades
            .Where(g => g.Key.Item1.StudentId == student.StudentId)
            .ToList();

        if (!studentGrades.Any())
            return null;

        double totalWeighted = 0;
        int totalCredits = 0;

        foreach (var entry in studentGrades)
        {
            var grade = entry.Value;
            var course = entry.Key.Item2;

            totalWeighted += grade * course.Credits;
            totalCredits += course.Credits;
        }

        return totalWeighted / totalCredits;
    }

    public (TStudent student, double grade)? GetTopStudent(TCourse course)
    {
        var courseGrades = _grades
            .Where(g => EqualityComparer<TCourse>.Default.Equals(g.Key.Item2, course))
            .ToList();

        if (!courseGrades.Any())
            return null;

        var top = courseGrades
            .OrderByDescending(g => g.Value)
            .First();

        return (top.Key.Item1, top.Value);
    }
}

//
// Demo Main Function (Useful for Viva / Interview)
//
public class UniversityCourse
{
    public static void Run()
    {
        var student1 = new EngineeringStudent
        {
            StudentId = 1,
            Name = "Krishna",
            Semester = 3,
            Specialization = "CSE"
        };

        var student2 = new EngineeringStudent
        {
            StudentId = 2,
            Name = "Rahul",
            Semester = 2,
            Specialization = "IT"
        };

        var course = new LabCourse
        {
            CourseCode = "CS101",
            Title = "Data Structures Lab",
            MaxCapacity = 2,
            Credits = 4,
            LabEquipment = "Computers",
            RequiredSemester = 2
        };

        var enrollmentSystem = new EnrollmentSystem<EngineeringStudent, LabCourse>();

        Console.WriteLine(enrollmentSystem.EnrollStudent(student1, course)); // True
        Console.WriteLine(enrollmentSystem.EnrollStudent(student2, course)); // True

        var gradeBook = new GradeBook<EngineeringStudent, LabCourse>(enrollmentSystem);

        gradeBook.AddGrade(student1, course, 85);
        gradeBook.AddGrade(student2, course, 92);

        Console.WriteLine($"GPA Krishna: {gradeBook.CalculateGPA(student1)}");
        Console.WriteLine($"Top Student: {gradeBook.GetTopStudent(course)?.student.Name}");
    }
}
