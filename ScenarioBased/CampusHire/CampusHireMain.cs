public class CampusHire
{
    public static void Run()
    {
        ApplicationManager manager = new ApplicationManager();

        while (true)
        {
            Console.WriteLine("\n===== CampusHire Applicant System =====");
            Console.WriteLine("1. Add Applicant");
            Console.WriteLine("2. Display All Applicants");
            Console.WriteLine("3. Search Applicant by ID");
            Console.WriteLine("4. Update Applicant");
            Console.WriteLine("5. Delete Applicant");
            Console.WriteLine("6. Exit");

            Console.Write("Enter Choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Applicant a = new Applicant();

                    Console.Write("Enter Applicant ID: ");
                    a.Id = Console.ReadLine();

                    Console.Write("Enter Name: ");
                    a.Name = Console.ReadLine();

                    Console.Write("Enter Current Location (Mumbai/Pune/Chennai): ");
                    a.CurrentLocation = Enum.Parse<CurrentLocation>(Console.ReadLine());

                    Console.Write("Enter Preferred Location: ");
                    a.PreferredLocation = Enum.Parse<PreferredLocation>(Console.ReadLine());

                    Console.Write("Enter Competency (.NET/JAVA/ORACLE/Testing): ");
                    a.Competency = Console.ReadLine();

                    Console.Write("Enter Passing Year: ");
                    a.PassingYear = int.Parse(Console.ReadLine());

                    manager.AddApplicant(a);
                    break;

                case 2:
                    manager.DisplayAll();
                    break;

                case 3:
                    Console.Write("Enter Applicant ID: ");
                    var found = manager.SearchById(Console.ReadLine());

                    if (found != null)
                        Console.WriteLine($"Applicant Found: {found.Name}");

                    break;

                case 4:
                    Console.Write("Enter Applicant ID: ");
                    manager.UpdateApplicantDetails(Console.ReadLine());
                    break;

                case 5:
                    Console.Write("Enter Applicant ID: ");
                    manager.DeleteApplicant(Console.ReadLine());
                    break;

                case 6:
                    return;
            }
        }
    }
}