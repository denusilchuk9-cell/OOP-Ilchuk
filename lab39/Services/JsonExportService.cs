using Newtonsoft.Json; 
using System.Collections.Generic; 
using System.IO; 
using System.Threading.Tasks; 
 
namespace OrderManager.Services 
{ 
    public class JsonExportService 
    { 
        { 
            var json = JsonConvert.SerializeObject(orders, Formatting.Indented); 
            await File.WriteAllTextAsync(filePath, json); 
            Console.WriteLine($"JSON exported to {filePath}"); 
        } 
    } 
