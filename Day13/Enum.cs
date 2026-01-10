public enum WeekDays
{

    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}

public enum ProductCategory
{
    Electronics = 1,
    Grocery = 2,
    Clothing = 3
}

public class Enum_Example
{
    public static string GetWeekDay(WeekDays weekDays, ref int numValue)
    {
        numValue = (int)weekDays;
        return weekDays.ToString();
    }

    public static void Run()
        {
            WeekDays today = WeekDays.Wednesday;
            Console.WriteLine("Today is: " + today);

            //int enumValue = (int)WeekDays.Friday;
            ProductCategory category = ProductCategory.Electronics;
            Console.WriteLine("Selected category: " + category + " with value " + (int)category);
            int numValuePara = 0;
            string variableForDay = GetWeekDay(WeekDays.Thursday, ref numValuePara);
            Console.WriteLine(variableForDay);
            Console.WriteLine(numValuePara);
        }
    public static String MenuByDay(WeekDays day)
        {
            switch(day)
            {
                case WeekDays.Monday:
                    return "Pasta";
                case WeekDays.Tuesday:
                    return "Tacos";
                case WeekDays.Wednesday:
                    return "Chicken Curry";
                case WeekDays.Thursday:
                    return "Pizza";
                case WeekDays.Friday:
                    return "Fish and Chips";
                case WeekDays.Saturday:
                    return "Burgers";
                case WeekDays.Sunday:
                    return "Roast Dinner";
                default:
                    return "Unknown Day";
            }
        }
}