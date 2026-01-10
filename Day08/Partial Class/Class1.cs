//Partial classes improve code organization, support teamwork, and allow separation of auto-generated code from manual code without modifying generated files.


public partial class Student1
{
    public string Course { get; set; }
    public double Marks { get; set; }

    public Student1(int rollNo, string name , string course , double marks)
    {
        RollNo = rollNo;
        Name = name;
        Course = course;
        Marks = marks;
    }

    public void DisplayAcademicInfo()
    {
        Console.WriteLine($"RollNo: {RollNo}, Name: {Name}, Course: {Course}, Marks: {Marks}");
    }
}

// Entry Point
class PartialClass
{
    public static void Run()
    {
        Student1 s1 = new Student1(1,"Ayush","Btech",58.00);
        //s1.DisplayBasicInfo();
        // s1.Course = "Btech";
        // s1.Marks = 58.00;
        s1.DisplayAcademicInfo();
    } 
}
