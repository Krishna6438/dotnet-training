using System.Net;

class MedicineUtility
{
    SortedDictionary<int, List<Medicine>> manage = new SortedDictionary<int, List<Medicine>>();


    public void AddMedicine(Medicine medicine)
    {
        if (medicine.Price <= 0)
        {
            throw new InvalidPriceException("Invalid Price");
        }
        if (medicine.ExpiryYear < DateTime.Now.Year)
        {
            throw new InvalidExpiryYearException("Invalid Expiry year");
        }
        foreach (var entry in manage.Values)
        {
            if (entry.Any(e => e.Id == medicine.Id))
            {
                throw new DuplicateMedicineException("Medicine already exists");
            }
        }
        if (!manage.ContainsKey(medicine.ExpiryYear))
            manage[medicine.ExpiryYear] = new List<Medicine>();

        manage[medicine.ExpiryYear].Add(medicine);
    }
    public void GetAllMedicine()
    {
        foreach (var kvp in manage)
        {
            foreach (var m in kvp.Value)
            {
                Console.WriteLine($"Details: {m.Id} {m.Name} {m.Price} {m.ExpiryYear}");
            }
        }
    }
    public void UpdateMedicinePrice(string id, int newPrice)
    {
        if (newPrice <= 0)
        {
            throw new InvalidPriceException("Invalid Price");
        }
        foreach (var list in manage.Values)
        {
            var med = list.FirstOrDefault(m => m.Id == id);
            if (med != null)
            {
                med.Price = newPrice;
                return;
            }
        }
        throw new MedicineNotFoundException("Medicine Not Found");
    }

    public static void Run()
    {
        MedicineUtility util = new();

        while (true)
        {
            Console.WriteLine("\n1 → Display all medicines");
            Console.WriteLine("2 → Update medicine price");
            Console.WriteLine("3 → Add medicine");
            Console.WriteLine("4 → Exit");

            int choice = int.Parse(Console.ReadLine());

            try
            {
                switch (choice)
                {
                    case 1:
                        util.GetAllMedicine();
                        break;

                    case 2:
                        Console.Write("Enter ID: ");
                        string id = Console.ReadLine();

                        Console.Write("Enter New Price: ");
                        int price = int.Parse(Console.ReadLine());

                        util.UpdateMedicinePrice(id, price);
                        Console.WriteLine("Price Updated");
                        break;

                    case 3:
                        Console.WriteLine("Enter: ID Name Price ExpiryYear");

                        var input = Console.ReadLine().Split();

                        Medicine med = new Medicine(
                            input[0],
                            input[1],
                            int.Parse(input[2]),
                            int.Parse(input[3])
                        );

                        util.AddMedicine(med);
                        Console.WriteLine("Medicine Added");
                        break;

                    case 4:
                        return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

}