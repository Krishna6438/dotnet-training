public partial class Student1
{
    public int RollNo { get; set; }
    public string Name { get; set; }

    public Student1(int rollNo, string name)
    {
        RollNo = rollNo;
        Name = name;
    }

    public void DisplayBasicInfo()
    {
        Console.WriteLine($"Roll No: {RollNo}, Name: {Name}");
    }
}