class Day02P
{
    public void CalculateElectricityBill(int units)
    {
        double bill = 0;

        if (units <= 199)
            bill = units * 1.20;
        else if (units <= 400)
            bill = (199 * 1.20) + ((units - 199) * 1.50);
        else if (units <= 600)
            bill = (199 * 1.20) + (201 * 1.50) + ((units - 400) * 1.80);
        else
            bill = (199 * 1.20) + (201 * 1.50) + (200 * 1.80) + ((units - 600) * 2.00);

        if (bill > 400)
            bill += bill * 0.15;   // 15% surcharge

        Console.WriteLine("Total Bill = " + bill);
    }


    public void CheckVowel(char ch)
{
    switch (char.ToLower(ch))
    {
        case 'a':
        case 'e':
        case 'i':
        case 'o':
        case 'u':
            Console.WriteLine("Vowel");
            break;
        default:
            Console.WriteLine("Consonant");
            break;
    }
}


public void TriangleType(int a, int b, int c)
{
    if (a == b && b == c)
        Console.WriteLine("Equilateral Triangle");
    else if (a == b || b == c || a == c)
        Console.WriteLine("Isosceles Triangle");
    else
        Console.WriteLine("Scalene Triangle");
}


public void FindQuadrant(int x, int y)
{
    if (x > 0 && y > 0)
        Console.WriteLine("First Quadrant");
    else if (x < 0 && y > 0)
        Console.WriteLine("Second Quadrant");
    else if (x < 0 && y < 0)
        Console.WriteLine("Third Quadrant");
    else if (x > 0 && y < 0)
        Console.WriteLine("Fourth Quadrant");
    else if (x == 0 && y == 0)
        Console.WriteLine("Origin");
    else
        Console.WriteLine("On Axis");
}

public void GradeDescription(char grade)
{
    switch (char.ToUpper(grade))
    {
        case 'E':
            Console.WriteLine("Excellent");
            break;
        case 'V':
            Console.WriteLine("Very Good");
            break;
        case 'G':
            Console.WriteLine("Good");
            break;
        case 'A':
            Console.WriteLine("Average");
            break;
        case 'F':
            Console.WriteLine("Fail");
            break;
        default:
            Console.WriteLine("Invalid Grade");
            break;
    }
}


public void Run()
{
    // 1. Electricity Bill
    Console.Write("Enter electricity units: ");
    int units = Convert.ToInt32(Console.ReadLine());
    CalculateElectricityBill(units);

    Console.WriteLine();

    // 2. Vowel or Consonant
    Console.Write("Enter a character: ");
    char ch = Convert.ToChar(Console.ReadLine());
    CheckVowel(ch);

    Console.WriteLine();

    // 3. Triangle Type
    Console.Write("Enter side 1: ");
    int a = Convert.ToInt32(Console.ReadLine());
    Console.Write("Enter side 2: ");
    int b = Convert.ToInt32(Console.ReadLine());
    Console.Write("Enter side 3: ");
    int c = Convert.ToInt32(Console.ReadLine());
    TriangleType(a, b, c);

    Console.WriteLine();

    // 4. Quadrant Finder
    Console.Write("Enter x coordinate: ");
    int x = Convert.ToInt32(Console.ReadLine());
    Console.Write("Enter y coordinate: ");
    int y = Convert.ToInt32(Console.ReadLine());
    FindQuadrant(x, y);

    Console.WriteLine();

    // 5. Grade Description
    Console.Write("Enter grade (E/V/G/A/F): ");
    char grade = Convert.ToChar(Console.ReadLine());
    GradeDescription(grade);
}


}