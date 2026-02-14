using System;
using System.Collections.Generic;

public class ECommerce
{
    public Dictionary<string, int> Consolidate(List<(string sku, int qty)> scans)
    {
        Dictionary<string, int> result = new Dictionary<string, int>();

        foreach (var scan in scans)
        {
            
            if (scan.qty <= 0)
                continue;

            
            if (result.ContainsKey(scan.sku))
                result[scan.sku] += scan.qty;
            else
                result[scan.sku] = scan.qty;
        }

        return result;
    }

    public static void Run()
    {
        var scans = new List<(string sku, int qty)>
        {
            ("A101", 2),
            ("B205", 1),
            ("A101", 3),
            ("C111", -1)
        };

        ECommerce cart = new ECommerce();
        var consolidated = cart.Consolidate(scans);

        foreach (var item in consolidated)
        {
            Console.WriteLine($"{item.Key} : {item.Value}");
        }
    }
}
