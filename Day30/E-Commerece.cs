public class Product
{
    public string? ProductCode { get; set; }
    public string? ProductName { get; set; }
    public string? Category { get; set; }
    public double Price { get; set; }
    public int StockQuantity { get; set; }

}

public class InventoryManager
{
    List<Product> products = new List<Product>();
    int idCounter = 1;
    public void AddProduct(string name, string category, double price, int stock)
    {
        Product p = new Product()
        {
            ProductCode = "P" + idCounter.ToString("D3"),
            ProductName = name,
            Category = category,
            Price = price,
            StockQuantity = stock
        };
        products.Add(p);
        idCounter++;
    }

    public SortedDictionary<string, List<Product>> GroupProductsByCategory()
    {
        SortedDictionary<string, List<Product>> grouped = new SortedDictionary<string, List<Product>>();
        foreach (var product in products)
        {
            if (!grouped.ContainsKey(product.Category))
            {
                grouped[product.Category] = new List<Product>();
            }
            grouped[product.Category].Add(product);
        }
        return grouped;
    }

    public bool UpdateStock(string productCode, int quantity)
    {
        foreach (var product in products)
        {
            if (product.ProductCode.Equals(productCode, StringComparison.OrdinalIgnoreCase))
            {
                if (product.StockQuantity >= quantity)
                {
                    product.StockQuantity -= quantity; // update stock
                    return true;
                }
                else
                {
                    return false; // insufficient stock
                }
            }
        }
        return false; // product not found
    }


    public List<Product> GetProductsBelowPrice(double maxPrice)
    {
        return products.Where(p => p.Price < maxPrice).ToList();
    }

    public Dictionary<string, int> GetCategoryStockSummary()
    {
        Dictionary<string, int> summary = new Dictionary<string, int>();
        foreach (var product in products)
        {
            if (!summary.ContainsKey(product.Category))
            {
                summary[product.Category] = 0;
            }
            summary[product.Category] +=(product.StockQuantity);
        }
        return summary;
    }
}

public class EcommerceManagement
{
    public static void Run()
    {
        InventoryManager inventory = new InventoryManager();

        // Add products
        inventory.AddProduct("iPhone 15", "Electronics", 75000, 10);
        inventory.AddProduct("Laptop", "Electronics", 65000, 5);
        inventory.AddProduct("T-Shirt", "Clothing", 1200, 30);
        inventory.AddProduct("Jeans", "Clothing", 2500, 20);
        inventory.AddProduct("C# Programming Book", "Books", 900, 15);

        // Display products grouped by category
        Console.WriteLine("🛒 Products Grouped by Category:\n");
        SortedDictionary<string, List<Product>> groupedProducts =
            inventory.GroupProductsByCategory();

        foreach (var category in groupedProducts)
        {
            Console.WriteLine($"Category: {category.Key}");
            foreach (var product in category.Value)
            {
                Console.WriteLine(
                    $"{product.ProductCode} | {product.ProductName} | ₹{product.Price} | Stock: {product.StockQuantity}"
                );
            }
            Console.WriteLine();
        }

        // Update stock after a sale
        Console.WriteLine("📦 Updating Stock:");
        bool updated = inventory.UpdateStock("P001", 3);
        Console.WriteLine(updated
            ? "Stock updated successfully\n"
            : "Stock update failed\n");

        // Find products below a certain price
        Console.WriteLine("💰 Products Below ₹2000:");
        var budgetProducts = inventory.GetProductsBelowPrice(2000);
        foreach (var product in budgetProducts)
        {
            Console.WriteLine($"{product.ProductName} - ₹{product.Price}");
        }

        // Display category-wise stock summary
        Console.WriteLine("\n📊 Category Stock Summary:");
        Dictionary<string, int> stockSummary =
            inventory.GetCategoryStockSummary();

        foreach (var entry in stockSummary)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value} items");
        }

        Console.WriteLine("\nProgram completed successfully.");
    }
}