// Classes and object

using System.Net;

// class Student
// {
//     int id;
//     string name;
//     string branch;

//     Student(int id, string name, string branch)
//     {
//         this.id = id;
//         this.name = name;
//         this.branch = branch;
//     }

//     public void SetId(int id)
//     {
//         this.id = id;

//     }
//     public void SetName(string name)
//     {
//         this.name = name;
//     }

//     public void SetBranch(string branch)
//     {
//         this.branch = branch;
//     }

//     public int GetId()
//     {
//         return id;
//     }

//     public string GetName()
//     {
//         return name;
//     }

//     public string GetBranch()
//     {
//         return branch;
//     }

//     public static void Run()
//     {
//         Student s = new Student(1, "Ayush", "IT");
//         Console.WriteLine(s.GetId() + " " + s.GetName() + " " + s.GetBranch());
//     }

// }


// using System;

// class Employee
// {
//     public int id;
//     public string name;
//     public string domain;

//     public Employee(int id, string name, string domain)
//     {
//         this.id = id;
//         this.name = name;
//         this.domain = domain;
//     }

//     public void GetData()
//     {
//         Console.WriteLine($"ID: {id}, Name: {name}, Domain: {domain}");
//     }
// }

// class Competition
// {
//     public string competitionName;
//     public string level;

//     public Competition(string competitionName, string level)
//     {
//         this.competitionName = competitionName;
//         this.level = level;
//     }

//     public void GetCompetitionInfo()
//     {
//         Console.WriteLine($"Competition: {competitionName}, Level: {level}");
//     }
// }

// class CompetitionResult
// {
//     public Employee employee;
//     public Competition competition;
//     public int score;
//     public string result;



//     public int position()
//     {
//         return 1;
//     }

//     public CompetitionResult(Employee employee, Competition competition, int score)
//     {
//         this.employee = employee;
//         this.competition = competition;
//         this.score = score;
//         this.result = score >= 50 ? "Qualified" : "Not Qualified";
//     }

//     public void DisplayResult()
//     {
//         employee.GetData();
//         competition.GetCompetitionInfo();
//         Console.WriteLine($"Score: {score}, Result: {result}");
//     }

    
// }

// class Day03
// {
//     public static void Run()
//     {
//         Employee emp = new Employee(101, "Krishna", "Web Development");
//         Competition comp = new Competition("Hackathon", "National");

//         CompetitionResult res = new CompetitionResult(emp, comp, 78);
//         res.DisplayResult();
//     }
// }




// using System;

// public class Employee
// {
//     public int id;
//     public String Name;
//     public String Designation;
    
// }

// public class Competition
// {
//     public int Id;
//     public String CompetitionName;
//     public String level;
//     public int Score;

// }

// public class CompetitionResult
// {
//    public Competition Competition;
//    public Employee Employee;    
//    public int Rank;

//    public string Comments;
// }

// public class Prog
// {
//     public static void Main(string[] args)
//     {
//         CompetitionResult[] competitionResults=new CompetitionResult[5];
//         competitionResults[0] = new CompetitionResult();
//         competitionResults[0].Competition=new Competition()
//         {
//             Id = 1,
//             CompetitionName = "Coding Contest",
//             level = "Intermediate",
//             Score = 85
//         };
//         competitionResults[0].Employee=new Employee()
//         {
//             id = 101,
//             Name = "Annu",
//             Designation = "Software Trainee"
            
//         };
//         competitionResults[0].Rank=1;
//         competitionResults[0].Comments="Winner";



//         Console.WriteLine("---- Competition Result ----");
//         Console.WriteLine("Employee ID      : " + competitionResults[0].Employee.id);
//         Console.WriteLine("Employee Name    : " + competitionResults[0].Employee.Name);
//         Console.WriteLine("Designation      : " + competitionResults[0].Employee.Designation);
//         Console.WriteLine("Competition Name : " + competitionResults[0].Competition.CompetitionName);
//         Console.WriteLine("Level            : " + competitionResults[0].Competition.level);
//         Console.WriteLine("Score            : " + competitionResults[0].Competition.Score);
//         Console.WriteLine("Rank             : " + competitionResults[0].Rank);
//         Console.WriteLine("Comments         : " + competitionResults[0].Comments);
//     }
// }



// model for college

class HighSchool
{
    
}

class UnderGraduate
{
    
}

class PostGraduate
{
    
}



