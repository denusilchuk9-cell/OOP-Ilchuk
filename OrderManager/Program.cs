using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace OrderManager
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Order Manager System ===");

            var orders = new List<Order>
            {
                new Order { Id = 1, Product = "Laptop", Quantity = 1, Price = 1200m },
                new Order { Id = 2, Product = "Mouse", Quantity = 2, Price = 25m },
                new Order { Id = 3, Product = "Keyboard", Quantity = 1, Price = 75m }
            };

            Console.WriteLine("\nCurrent orders:");
            foreach (var order in orders)
            {
                Console.WriteLine($"  Order #{order.Id}: {order.Product} - {order.Quantity} pcs - ${order.Price}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }