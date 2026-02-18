using System; // Console
using System.Collections.Generic;
using System.Text.RegularExpressions; // List

namespace ItTechGenie.M1.OOP.Q5
{
    public class OrderPricing
    {
        public static void Run()
        {
            Console.WriteLine("Paste input lines, end with EMPTY line:");
            var lines = ConsoleInput.ReadLines();                               // read input

            var engine = new OrderEngine();                                     // create engine
            engine.Run(lines);                                                  // run
        }
    }

    public static class ConsoleInput
    {
        public static string[] ReadLines()
        {
            var list = new List<string>();                                      // store lines
            while (true)
            {
                var line = Console.ReadLine();                                  // read
                if (string.IsNullOrWhiteSpace(line)) break;                     // stop
                list.Add(line);                                                 // add
            }
            return list.ToArray();                                              // return
        }
    }

    public class OrderEngine
    {
        private readonly Dictionary<string, Order> _orders = new();             // order store

        public void Run(string[] lines)
        {
            foreach (var raw in lines)                                          // process
            {
                var cmd = Command.Parse(raw);                                   // parse

                if (cmd.Name == "ORDER")                                        // create order
                {
                    var id = cmd.Get("id");                                     // order id
                    var customer = cmd.Get("customer");                         // customer
                    var items = cmd.Get("items");                               // items string
                    var address = cmd.Get("address");                           // address may include commas, quotes, emoji
                    _orders[id] = new Order(id, customer, items, address);      // store
                }
                else if (cmd.Name == "APPLY_COUPON")                             // apply coupon
                {
                    var id = cmd.Get("id");                                     // order id
                    var coupon = cmd.Get("code");                               // coupon code
                    var strategy = PricingStrategyFactory.Create(coupon);       // ✅ TODO factory
                    _orders[id].ApplyPricing(strategy, coupon);                 // apply pricing
                }
                else if (cmd.Name == "PRINT")                                    // print
                {
                    var id = cmd.Get("id");                                     // order id
                    Console.WriteLine(_orders[id].GetSummary());                // print summary
                }
            }
        }
    }

    public class Order
    {
        public string Id { get; }
        public string Customer { get; }
        public string Items { get; }
        public string Address { get; }

        private decimal _subtotal = 15000m;                                     // assume parsed subtotal for demo
        private decimal _total;                                                  // total after coupon

        public Order(string id, string customer, string items, string address)
        {
            Id = id; Customer = customer; Items = items; Address = address;     // assign
            _total = _subtotal;                                                 // initial total
        }

        public void ApplyPricing(IPricingStrategy strategy, string couponCode)
        {
            _total = strategy.Apply(_subtotal, couponCode);                      // polymorphic apply
        }

        public string GetSummary()
        {
            return $"Order[{Id}] Customer={Customer} | Subtotal={_subtotal} | Total={_total} | Address={Address}";
        }
    }

    public interface IPricingStrategy
    {
        decimal Apply(decimal subtotal, string couponCode);                       // apply pricing rule
    }

    public sealed class NoCoupon : IPricingStrategy
    {
        public decimal Apply(decimal subtotal, string couponCode) => subtotal;    // no change
    }

    public sealed class PercentageCoupon : IPricingStrategy
    {
        // ✅ TODO: Student must implement only this method
        public decimal Apply(decimal subtotal, string couponCode)
        {
            // TODO:
            // - read percentage from couponCode like "SAVE@20%#FEB" => 20
            // - apply discount: subtotal * (1 - percent/100)

            var match = Regex.Match(couponCode,@"@(\d+)%");
            if(!match.Success)
                throw new ArgumentException("Invalid coupon code format");

            int discount = int.Parse(match.Groups[1].Value);
            return subtotal *(1-discount/100m);
            
        }
    }

    public sealed class FlatCoupon : IPricingStrategy
    {
        // ✅ TODO: Student must implement only this method
        public decimal Apply(decimal subtotal, string couponCode)
        {
            // TODO:
            // - read flat amount from couponCode like "FLAT@500#X" => 500
            // - total cannot go below 0
            var match = Regex.Match(couponCode, @"FLAT@(\d+)");
            if (!match.Success)
            {
                throw new ArgumentException("Invalid coupon code format");
            }
            
            
            decimal flat = int.Parse(match.Groups[1].Value);
            decimal total = subtotal - flat;
            return total<0?0:total;
            
        }
    }

    public static class PricingStrategyFactory
    {
        // ✅ TODO: Student must implement only this method
        public static IPricingStrategy Create(string couponCode)
        {
            // TODO:
            // - if couponCode contains '%' => PercentageCoupon
            // - else if contains "FLAT@" => FlatCoupon
            // - else => NoCoupon
            if (couponCode.Contains('%'))
            {
                return new PercentageCoupon();
            }
            if (couponCode.Contains("FLAT@"))
            {
                return new FlatCoupon();
            }
            return new NoCoupon();
        }
    }

    public class Command
    {
        public string Name { get; }
        private readonly Dictionary<string, string> _kv;

        private Command(string name, Dictionary<string, string> kv) { Name = name; _kv = kv; }
        public string Get(string key) => _kv.TryGetValue(key, out var v) ? v : "";

        public static Command Parse(string line)
        {
            var parts = line.Split('|');
            var name = parts[0].Trim();
            var kv = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            for (int i = 1; i < parts.Length; i++)
            {
                var p = parts[i];
                var idx = p.IndexOf('=');
                if (idx <= 0) continue;
                var key = p.Substring(0, idx).Trim();
                var val = p.Substring(idx + 1).Trim().Trim('"');
                kv[key] = val;
            }

            return new Command(name, kv);
        }
    }
}