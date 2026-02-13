public class CreditRiskProcessor
{
    public static bool validateCustomerDetails(int age, String employmentType, double monthlyIncome, double dues, int creditScore, int defaults)
    {
        // Age validation

        if(age<21 || age > 65)
        {
            throw new InvalidCreditDataException("Invalid Age");
        }
        // Employment Type Validation

        if(employmentType!="Salaried" && employmentType != "Self-Employed")
        {
            throw new InvalidCreditDataException("Invalid Employment type");
        }
        //Monthly Income Validation
        if (monthlyIncome < 20000)
        {
            throw new InvalidCreditDataException("Invalid Salary");
        }

        // Credit card dues Validation
        if (dues < 0)
        {
            throw new InvalidCreditDataException("Invalid monthly dues");
        }

        // Credit Card Validation
        
        if(creditScore<300 || creditScore > 900)
        {
            throw new InvalidCreditDataException("Invalid credit score");
        }

        // Number of Loans Default Validation
        if (defaults < 0)
        {
            throw new InvalidCreditDataException("Invalid default count");
        }

        return true;
    }

    // Function to calculate Calculate Credit Limit
    public static double calculateCreditLimit(double monthlyIncome, double dues, int creditScore, int defaults)
    {
        // Calculating debt ratio
        
        double DebtRatio = dues / (monthlyIncome*12);

        
        if (creditScore < 600 || defaults >= 3 || DebtRatio > 0.4)
        {
            return 50000; // High risk
        }

        
        if (creditScore >= 750 && defaults == 0 && DebtRatio < 0.25)
        {
            return 300000; // Low risk
        }

        
        return 150000; // Medium risk 
    }
}

