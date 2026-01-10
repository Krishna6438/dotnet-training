
    public enum Semester
    {
        Semester1=1,
        Semester2=2
    }
    public enum SubjectsSem1
    {
        Physics=1,
        Maths=2,
        Mechanical=3,
        Electronics=4,
        Python=5
    }
    public enum SubjectsSem2
    {
        Cpp=1,
        DiscreteMaths=2,
        DSA=3,
        SoftSkills=4,
        Devops=5
    }
    public class Semester_Subject
    {
        public static void Run()
        {

            int[,] semesterSub = new int[2, 5];

            // Semester 1 subjects
            semesterSub[0, 0] = (int)SubjectsSem1.Physics;
            semesterSub[0, 1] = (int)SubjectsSem1.Maths;
            semesterSub[0, 2] = (int)SubjectsSem1.Mechanical;
            semesterSub[0, 3] = (int)SubjectsSem1.Electronics;
            semesterSub[0, 4] = (int)SubjectsSem1.Python;

            // Semester 2 subjects
            semesterSub[1, 0] = (int)SubjectsSem2.Cpp;
            semesterSub[1, 1] = (int)SubjectsSem2.DiscreteMaths;
            semesterSub[1, 2] = (int)SubjectsSem2.DSA;
            semesterSub[1, 3] = (int)SubjectsSem2.SoftSkills;
            semesterSub[1, 4] = (int)SubjectsSem2.Devops;

            // Display label (name) and value
            Console.WriteLine("Semester 1 Subjects:");
            for (int i = 0; i < 5; i++)
            {
                SubjectsSem1 subject =
                    (SubjectsSem1)semesterSub[0, i];
                Console.WriteLine($"Label: {subject}, Value: {(int)subject}");
            }

            Console.WriteLine("\nSemester 2 Subjects:");
            for (int i = 0; i < 5; i++)
            {
                SubjectsSem2 subject =
                    (SubjectsSem2)semesterSub[1, i];
                Console.WriteLine($"Label: {subject}, Value: {(int)subject}");
            }
        
        }
    }
