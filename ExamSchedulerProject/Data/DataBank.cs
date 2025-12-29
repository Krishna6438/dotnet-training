using System;
using System.Collections.Generic;
using System.Text;
using ExamSchedule.Model;

namespace ExamSchedule.Data
{
    public static class DataBank
    {
        private static List<Student> Students = new();
        private static List<Section> Sections = new();

        static DataBank()
        {
            // Students
            Students.Add(new Student { Id = 1, Name = "Ansh", SectionId = 1 });
            Students.Add(new Student { Id = 2, Name = "Harsh", SectionId = 1 });
            Students.Add(new Student { Id = 3, Name = "Monika", SectionId = 2 });
            Students.Add(new Student { Id = 4, Name = "Alice", SectionId = 2 });

            // Sections
            Sections.Add(new Section { Id = 1, Name = "Section A" });
            Sections.Add(new Section { Id = 2, Name = "Section B" });
        }

        public static List<Student> GetStudents()
        {
            return Students;
        }

        public static List<Section> GetSections()
        {
            return Sections;
        }
    }
}