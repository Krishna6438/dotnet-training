using ExamSchedule.Data;

namespace ExamSchedule
{
    public class MainClass
    {
        public static void Run()
        {
            var students = DataBank.GetStudents();
            var sections = DataBank.GetSections();

            foreach (var section in sections)
            {
                Console.WriteLine($"Section: {section.Name}");

                var sectionStudents = students
                    .Where(s => s.SectionId == section.Id)
                    .ToList();

                foreach (var student in sectionStudents)
                {
                    Console.WriteLine($"  Student: {student.Name}");
                }

                Console.WriteLine();
            }
        }
    }
}