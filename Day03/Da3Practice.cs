using System;

class Day03Practice
{
    // 1. Valid Date Check
    // Checks whether a given day, month, and year form a valid calendar date
    static void ValidDateCheck()
    {
        // Read day, month, and year from user
        Console.Write("Enter Day: ");
        int day = int.Parse(Console.ReadLine());

        Console.Write("Enter Month: ");
        int month = int.Parse(Console.ReadLine());

        Console.Write("Enter Year: ");
        int year = int.Parse(Console.ReadLine());

        // Check leap year condition
        bool isLeap = (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);
        int daysInMonth = 0;

        // Validate month
        if (month >= 1 && month <= 12)
        {
            // Set days based on month
            if (month == 2)
                daysInMonth = isLeap ? 29 : 28;
            else if (month == 4 || month == 6 || month == 9 || month == 11)
                daysInMonth = 30;
            else
                daysInMonth = 31;

            // Validate day
            if (day >= 1 && day <= daysInMonth)
                Console.WriteLine("Valid Date");
            else
                Console.WriteLine("Invalid Date");
        }
        else
        {
            Console.WriteLine("Invalid Month");
        }
    }

    // 2. ATM Withdrawal
    // Simulates ATM transaction using nested if statements
    static void ATMCheck()
    {
        Console.Write("Insert Card? (yes/no): ");
        string card = Console.ReadLine();

        // Check if card is inserted
        if (card == "yes")
        {
            Console.Write("Enter PIN: ");
            int pin = int.Parse(Console.ReadLine());

            // Validate PIN
            if (pin == 1234)
            {
                Console.Write("Enter Balance: ");
                int balance = int.Parse(Console.ReadLine());

                Console.Write("Enter Withdraw Amount: ");
                int amount = int.Parse(Console.ReadLine());

                // Check sufficient balance
                if (balance >= amount)
                    Console.WriteLine("Withdrawal Successful");
                else
                    Console.WriteLine("Insufficient Balance");
            }
            else
                Console.WriteLine("Invalid PIN");
        }
        else
            Console.WriteLine("Please Insert Card");
    }

    // 3. Profit / Loss
    // Calculates profit or loss percentage
    static void ProfitLoss()
    {
        Console.Write("Enter Cost Price: ");
        double cp = double.Parse(Console.ReadLine());

        Console.Write("Enter Selling Price: ");
        double sp = double.Parse(Console.ReadLine());

        // Check profit
        if (sp > cp)
        {
            double profit = sp - cp;
            Console.WriteLine($"Profit = {(profit / cp) * 100}%");
        }
        // Check loss
        else if (cp > sp)
        {
            double loss = cp - sp;
            Console.WriteLine($"Loss = {(loss / cp) * 100}%");
        }
        else
            Console.WriteLine("No Profit No Loss");
    }

    // 4. Rock Paper Scissors
    // Determines winner between two players
    static void RockPaperScissors()
    {
        Console.Write("Player 1 (rock/paper/scissors): ");
        string p1 = Console.ReadLine();

        Console.Write("Player 2 (rock/paper/scissors): ");
        string p2 = Console.ReadLine();

        // Check draw
        if (p1 == p2)
            Console.WriteLine("Draw");
        // Check Player 1 winning conditions
        else if (
            (p1 == "rock" && p2 == "scissors") ||
            (p1 == "paper" && p2 == "rock") ||
            (p1 == "scissors" && p2 == "paper"))
            Console.WriteLine("Player 1 Wins");
        // Otherwise Player 2 wins
        else
            Console.WriteLine("Player 2 Wins");
    }

    // 5. Simple Calculator
    // Performs arithmetic operation using switch
    static void Calculator()
    {
        Console.Write("Enter First Number: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Enter Second Number: ");
        int b = int.Parse(Console.ReadLine());

        Console.Write("Enter Operator (+ - * /): ");
        char op = char.Parse(Console.ReadLine());

        // Perform operation based on operator
        switch (op)
        {
            case '+':
                Console.WriteLine(a + b);
                break;
            case '-':
                Console.WriteLine(a - b);
                break;
            case '*':
                Console.WriteLine(a * b);
                break;
            case '/':
                if (b != 0)
                    Console.WriteLine(a / b);
                else
                    Console.WriteLine("Cannot divide by zero");
                break;
            default:
                Console.WriteLine("Invalid Operator");
                break;
        }
    }

    // MAIN RUN FUNCTION
    // Displays menu and calls selected program
    public static void Run()
    {
        Console.WriteLine("1. Valid Date Check");
        Console.WriteLine("2. ATM Withdrawal");
        Console.WriteLine("3. Profit / Loss");
        Console.WriteLine("4. Rock Paper Scissors");
        Console.WriteLine("5. Calculator");

        Console.Write("Choose Option: ");
        int choice = int.Parse(Console.ReadLine());

        // Call selected function
        switch (choice)
        {
            case 1: ValidDateCheck(); break;
            case 2: ATMCheck(); break;
            case 3: ProfitLoss(); break;
            case 4: RockPaperScissors(); break;
            case 5: Calculator(); break;
            default: Console.WriteLine("Invalid Choice"); break;
        }
    }
}
