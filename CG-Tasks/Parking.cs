using System;
using System.Collections.Generic;

public class Bike
{
    public string? Model { get; set; }
    public string? Brand { get; set; }
    public int PricePerDay { get; set; }
}

public class BikeUtility
{
    
    private SortedDictionary<int, Bike> bikeDetails = new SortedDictionary<int, Bike>();

    public void AddBikeDetails(string model, string brand, int pricePerDay)
    {
        int key = bikeDetails.Count + 1;

        Bike bike = new Bike
        {
            Model = model,
            Brand = brand,
            PricePerDay = pricePerDay
        };

        bikeDetails.Add(key, bike);
    }

    public SortedDictionary<string, List<Bike>> GroupBikesByBrand()
    {
        SortedDictionary<string, List<Bike>> grouped = new SortedDictionary<string, List<Bike>>();

        foreach (var bike in bikeDetails.Values)
        {
            if (!grouped.ContainsKey(bike.Brand))
            {
                grouped[bike.Brand] = new List<Bike>();
            }

            grouped[bike.Brand].Add(bike);
        }

        return grouped;
    }
}


public class ParkingCharge
{
    public static void Run()
    {
        BikeUtility utility = new BikeUtility();
        int choice = 0;

        while(choice != 3)
        {
            Console.WriteLine("Enter your choice........");
            Console.WriteLine("1.Add Bike Details");
            Console.WriteLine("2.Group Bikes By Brand");
            Console.WriteLine("3.Exit");
            choice = int.Parse(Console.ReadLine());

            if(choice == 1)
            {
                Console.WriteLine("Enter the model: ");
                string ?model = Console.ReadLine();
                Console.WriteLine("Enter brand name: ");
                string? brand = Console.ReadLine();
                Console.WriteLine("Enter per day charge: ");
                int pay = int.Parse(Console.ReadLine());

                utility.AddBikeDetails(model,brand,pay);
                
                Console.WriteLine("Bike details added successfully\n");
            }

            
            else if (choice == 2)
            {
                var grouped = utility.GroupBikesByBrand();

                foreach (var group in grouped)
                {
                    Console.WriteLine(group.Key);
                    foreach (var bike in group.Value)
                    {
                        Console.WriteLine(bike.Model);
                    }
                    Console.WriteLine();
                }
            }

            
        }

    }
}

