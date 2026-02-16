namespace ECommerceInventorySystem
{
    public interface IProduct
    {
        int Id { get; }
        string Name { get; }
        decimal Price { get; }
        Category Category { get; }
    }

    public enum Category { Electronics, Clothing, Books, Groceries }

    // 1. Create a generic repository for products
    public class ProductRepository<T> where T : class, IProduct
    {
        private List<T> _products = new List<T>();

        // TODO: Implement method to add product with validation
        public void AddProduct(T product)
        {
            // Rule: Product ID must be unique
            // Rule: Price must be positive
            // Rule: Name cannot be null or empty
            // Add to collection if validation passes
            if (_products.Any(p => p.Id == product.Id))
            {
                Console.WriteLine("Id must be unique.");
                return;
            }
            if (product.Price <= 0)
            {
                Console.WriteLine("Price must be positive.");
                return;
            }
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                Console.WriteLine("Name cannot be null or empty.");
                return;
            }
            _products.Add(product);
        }

        // TODO: Create method to find products by predicate
        public IEnumerable<T> FindProducts(Func<T, bool> predicate)
        {
            // Should return filtered products
            return _products.Where(predicate);
        }

        // TODO: Calculate total inventory value
        public decimal CalculateTotalValue()
        {
            // Return sum of all product prices
            return _products.Sum(p => p.Price);
        }
    }

    // 2. Specialized electronic product
    public class ElectronicProduct : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category => Category.Electronics;
        public int WarrantyMonths { get; set; }
        public string Brand { get; set; }
    }

    // 3. Create a discounted product wrapper
    public class DiscountedProduct<T> where T : IProduct
    {
        private T _product;
        private decimal _discountPercentage;

        public DiscountedProduct(T product, decimal discountPercentage)
        {
            // TODO: Initialize with validation
            // Discount must be between 0 and 100
            if (discountPercentage < 0 || discountPercentage > 100)
            {
                throw new ArgumentException("Discount must be between 0 and 100");
            }
            _product = product;
            _discountPercentage = discountPercentage;
        }

        // TODO: Implement calculated price with discount
        public decimal DiscountedPrice => _product.Price * (1 - _discountPercentage / 100);

        // TODO: Override ToString to show discount details
        public override string ToString()
        {
            return $"{_product.Name} | Original: {_product.Price} | " +
                $"Discount: {_discountPercentage}% | Final: {DiscountedPrice}";
        }
    }

    // 4. Inventory manager with constraints
    public class InventoryManager
    {
        // TODO: Create method that accepts any IProduct collection
        public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
        {
            // a) Print all product names and prices
            // b) Find the most expensive product
            // c) Group products by category
            // d) Apply 10% discount to Electronics over $500
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name} - {product.Price}");
            }

            var expensive = products.OrderByDescending(p => p.Price).FirstOrDefault();


            var grouped = products.GroupBy(p => p.Category);
            foreach (var group in grouped)
            {
                Console.WriteLine($"\nCategory: {group.Key}");

                foreach (var product in group)
                {
                    Console.WriteLine(product.Name);
                }
            }

            var discounted = products.Where(p => p.Category == Category.Electronics && p.Price > 500)
                                .Select(p => new DiscountedProduct<T>(p, 10));

            Console.WriteLine("\nDiscounted Products:");

            foreach (var product in discounted)
            {
                Console.WriteLine(product);
            }
        }

        // TODO: Implement bulk price update with delegate
        public void UpdatePrices<T>(List<T> products, Func<T, decimal> priceAdjuster)
    where T : IProduct
        {
            foreach (var product in products)
            {
                try
                {
                    var newPrice = priceAdjuster(product);

                    if (newPrice <= 0)
                        throw new Exception("Invalid adjusted price");

                    // Works only if mutable object
                    if (product is ElectronicProduct ep)
                    {
                        ep.Price = newPrice;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating {product.Name}: {ex.Message}");
                }
            }
        }

    }

    public class ECommerceInventory
    {
        public static void Run()
        {
            var repo = new ProductRepository<ElectronicProduct>();

            var p1 = new ElectronicProduct
            {
                Id = 1,
                Name = "Laptop",
                Price = 1200,
                Brand = "Dell",
                WarrantyMonths = 24
            };

            var p2 = new ElectronicProduct
            {
                Id = 2,
                Name = "Headphones",
                Price = 300,
                Brand = "Sony",
                WarrantyMonths = 12
            };

            var p3 = new ElectronicProduct
            {
                Id = 3,
                Name = "Smartphone",
                Price = 800,
                Brand = "Samsung",
                WarrantyMonths = 18
            };

            repo.AddProduct(p1);
            repo.AddProduct(p2);
            repo.AddProduct(p3);

            Console.WriteLine("\nTotal Inventory Value:");
            Console.WriteLine(repo.CalculateTotalValue());

            var manager = new InventoryManager();

            Console.WriteLine("\nProcessing Products:\n");
            manager.ProcessProducts(repo.FindProducts(p => true));

            Console.WriteLine("\nUpdating Prices (10% increase):\n");

            var productList = repo.FindProducts(p => true).ToList();

            manager.UpdatePrices(productList, p => p.Price * 1.10m);

            manager.ProcessProducts(productList);
        }
    }

}