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
 
            { 
                new Order { Id = 1, Product = "Laptop", Quantity = 1, Price = 1200 }, 
                new Order { Id = 2, Product = "Mouse", Quantity = 2, Price = 25 } 
            }; 
 
            foreach (var order in orders) 
            { 
                Console.WriteLine($"Order {order.Id}: {order.Product}"); 
            } 
 
            var jsonExport = new Services.JsonExportService(); 
            await jsonExport.ExportOrdersAsync(orders, "orders.json"); 
 
            Console.WriteLine("Press any key..."); 
            Console.ReadKey(); 
        } 
    } 
} 
