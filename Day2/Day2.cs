using System;

class Day02
{
    // Method to check whether a number is even
    public bool IsEven(int n)
    {
        // If remainder when divided by 2 is 0, number is even
        if (n % 2 == 0)
        {
            return true;
        }

        // Otherwise, number is odd
        return false;
    }

    // Method to check height
    public string Height(int h)
    {
        if (h < 150) // Dwarf
        {
            return "Dwarf";
        }
        if (h > 150 && h < 165) // Average
        {
            return "Average";
        }
        if (h > 165 && h < 190) // Tall
        {
            return "Tall";
        }
        else
        {
            return "Abnormal";
        }
    }




    // Method to check maximum out of three numbers

    public int FindMax(int a, int b, int c)
    {
        return Math.Max(a, Math.Max(b, c));
    }



    // Method for leap year

    public bool CheckLeapYear(int year)
    {
        if (year <= 0)
        {
            return false;
        }
        if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
        {
            return true;
        }
        return false;
    }

    // Method to calculate roots of quadratic equation
    public void CalculateQuadraticRoots(double a, double b, double c)
    {
        // Check if a is zero
        if (a == 0)
        {
            Console.WriteLine("Not a quadratic equation.");
            return;
        }
        // Calculate discriminant
        double discriminant = (b * b) - (4 * a * c);

        if (discriminant > 0) // Two real and distinct roots
        {
            double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);

            Console.WriteLine("Roots are real and distinct:");
            Console.WriteLine($"Root 1 = {root1}");
            Console.WriteLine($"Root 2 = {root2}");
        }
        else if (discriminant == 0) // One real root
        {
            double root = -b / (2 * a);
            Console.WriteLine("Roots are real and equal:");
            Console.WriteLine($"Root = {root}");
        }
        else // Imaginary roots
        {
            Console.WriteLine("Roots are imaginary (no real roots).");
        }
    }

    // Method to check admission eligibility
    public string CheckAdmission(int math, int phy, int chem)
    {
        // Calculate total marks
        int total = math + phy + chem;

        // Check eligibility criteria
        if (math >= 65 && phy >= 55 && chem >= 50 && (total >= 180 || math + phy >= 140))
        {
            return "Eligible";
        }
        else
        {
            return "Not Eligible";
        }
    }






    // Entry method to run the program logic
    public static void Run()
    {
        // Create an object of Day02 class
        Day02 d = new Day02();

        // Loop runs continuously until user types "quit"
        while (true)
        {
            // Ask user for input
            Console.Write("Enter a number (or type 'quit' to exit): ");

            // Read input from the console (can be null)
            string? input = Console.ReadLine();

            // Check if user wants to exit the program
            // string.Equals is null-safe and ignores case (QUIT, quit, Quit, etc.)
            if (string.Equals(input, "quit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Thanks for using this...... ");
                break; // Exit the loop
            }

            // Try to convert input string to integer
            if (int.TryParse(input, out int number))
            {
                // If conversion is successful, check if the number is even
                Console.WriteLine($"Is {number} even: {d.IsEven(number)}");
            }
            else
            {
                // If input is neither a number nor 'quit'
                Console.WriteLine("Invalid Number......");
            }


        }

        // Height check
        Console.WriteLine("Enter height in cm only");
        string? height = Console.ReadLine(); // Read height input
        if (int.TryParse(height, out int n))// Convert height to integer
        {
            Console.WriteLine($"According to given height: {d.Height(160)}");
        }



        // find maximum out of three

        int a, b, c;

        Console.WriteLine("Write first number");
        int.TryParse(Console.ReadLine(), out a);

        Console.WriteLine("Write second number");
        int.TryParse(Console.ReadLine(), out b);

        Console.WriteLine("Write third number");
        int.TryParse(Console.ReadLine(), out c);


        Console.WriteLine("Maximum is: " + d.FindMax(a, b, c));




        // check admission criteria

        int math, phy, chem;
        // Input marks

        Console.WriteLine("Enter maths number"); 
        int.TryParse(Console.ReadLine(), out math);  

        Console.WriteLine("Enter physics number");
        int.TryParse(Console.ReadLine(), out phy);

        Console.WriteLine("Enter chemistry number");
        int.TryParse(Console.ReadLine(), out chem);

    // Check eligibility
        Console.WriteLine("Admission Eligibility: " + d.CheckAdmission(math, phy, chem));




        // Quadratic roots

        Console.Write("Enter value of a: ");
        double p = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter value of b: ");
        double q = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter value of c: ");
        double r = Convert.ToDouble(Console.ReadLine());

        d.CalculateQuadraticRoots(p,q,r);  // Call method to calculate roots



    }

}
