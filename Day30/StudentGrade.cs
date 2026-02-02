namespace StudentGradeManagementSystem
{
    public class Student
    {
        public int StudentId{get; set;}
        public string? Name{get; set;}
        public string? GradeLevel{get; set;}
        public Dictionary<string, double>? Subjects;
    }

    public class SchoolManager
    {
        private List<Student> students = new List<Student>();
        int idCounter = 1;
        public void AddStudent(string name, string gradeLevel)
        {
            Student s = new Student()
            {
                StudentId = idCounter++,
                Name = name,
                GradeLevel = gradeLevel
            };
            students.Add(s);
        }

        public void AddGrade(int studentId, string subject, double grade)
        {
            if(grade<0 || grade > 100)
            {
                Console.WriteLine("Invalid Grade.....");
                return;
            }
            foreach(var student in students)
            {
                
            }
        }


    }
}