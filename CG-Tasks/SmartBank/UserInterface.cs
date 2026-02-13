// Main Function for taking input and showing output
public class UserInterface
{
    public static void Run()
    {
        try{
            Customer c = new Customer();
            Console.WriteLine("Enter Customer Name:");
            c.Name = Console.ReadLine();
            Console.WriteLine("Enter Customer Age: ");
            c.Age= int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Employment Type: ");
            c.EmploymentType = Console.ReadLine();
            Console.WriteLine("Enter Monthly Income:");
            c.Income = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter existing credit dues");
            c.CreditCardDues = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter credit score: ");
            c.CreditScore = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter number of loan defaults");
            c.Number_Of_Loans_Defaults = int.Parse(Console.ReadLine());

            // Validation

            CreditRiskProcessor.validateCustomerDetails(c.Age, c.EmploymentType ,c.Income,c.CreditCardDues,c.CreditScore,c.Number_Of_Loans_Defaults);

            // Calculating credit limit 

            double creditLimit = CreditRiskProcessor.calculateCreditLimit(c.Income,c.CreditCardDues,c.CreditScore,c.Number_Of_Loans_Defaults);

            Console.WriteLine();
            Console.WriteLine($"Customer Name: {c.Name}");
            Console.WriteLine($"Approved Credit Limit: ₹{creditLimit}");
        }catch(InvalidCreditDataException e)
        {
            Console.WriteLine(e.Message);
        }catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }


    }
}