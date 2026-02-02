public class MenuItem
{
    public string? ItemName { get; set; }
    public string? Category { get; set; }
    public double Price { get; set; }
    public bool IsVegetarian { get; set; }
}

public class MenuManager
{
    private List<MenuItem> items = new List<MenuItem>();
    public void AddMenuItem(string name, string category, double price, bool isVeg)
    {
        if (price <= 0)
        {
            Console.WriteLine("Price must be greater than 0.");
            return;
        }
        MenuItem m = new MenuItem()
        {
            ItemName = name,
            Category = category,
            Price = price,
            IsVegetarian = isVeg
        };
        items.Add(m);
    }

    public Dictionary<string, List<MenuItem>> GroupItemsByCategory()
    {
        Dictionary<string, List<MenuItem>> grouped = new Dictionary<string, List<MenuItem>>();
        foreach (var item in items)
        {
            if (!grouped.ContainsKey(item.Category))
            {
                grouped[item.Category] = new List<MenuItem>();
            }
            grouped[item.Category].Add(item);
        }
        return grouped;
    }
    public List<MenuItem> GetVegetarianItems()
    {
        return items.Where(i => i.IsVegetarian == true).ToList();
    }

    public double CalculateAveragePriceByCategory(string category)
    {
        double totalPrice = 0;
        int count = 0;
        foreach (var item in items)
        {
            if (item.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
            {
                totalPrice += item.Price;
                count++;
            }
        }
        return count == 0 ? 0 : totalPrice / count;
    }
}

public class RestaurantMenu
{
    public static void Run()
    {
        MenuManager menuManager = new MenuManager();

        // Add menu items
        menuManager.AddMenuItem("Spring Rolls", "Appetizer", 150, true);
        menuManager.AddMenuItem("Chicken Wings", "Appetizer", 220, false);
        menuManager.AddMenuItem("Paneer Butter Masala", "Main Course", 320, true);
        menuManager.AddMenuItem("Butter Chicken", "Main Course", 380, false);
        menuManager.AddMenuItem("Gulab Jamun", "Dessert", 120, true);

        // Display menu grouped by category
        Console.WriteLine("🍽 Menu Grouped by Category:\n");
        Dictionary<string, List<MenuItem>> groupedMenu = menuManager.GroupItemsByCategory();

        foreach (var category in groupedMenu)
        {
            Console.WriteLine($"Category: {category.Key}");
            foreach (var item in category.Value)
            {
                Console.WriteLine(
                    $"{item.ItemName} - ₹{item.Price} - {(item.IsVegetarian ? "Veg" : "Non-Veg")}"
                );
            }
            Console.WriteLine();
        }

        // Display vegetarian-only menu
        Console.WriteLine("🥗 Vegetarian Menu:\n");
        var vegItems = menuManager.GetVegetarianItems();

        foreach (var item in vegItems)
        {
            Console.WriteLine($"{item.ItemName} ({item.Category}) - ₹{item.Price}");
        }

        // Calculate average price by category
        Console.WriteLine("\n💰 Average Prices by Category:");
        Console.WriteLine($"Appetizer: ₹{menuManager.CalculateAveragePriceByCategory("Appetizer")}");
        Console.WriteLine($"Main Course: ₹{menuManager.CalculateAveragePriceByCategory("Main Course")}");
        Console.WriteLine($"Dessert: ₹{menuManager.CalculateAveragePriceByCategory("Dessert")}");

        Console.WriteLine("\nProgram completed successfully.");
    }
}