}  using System.Collections.Generic; 
using System.IO; 
using System.Linq; 
using System.Threading.Tasks; 
 
namespace OrderManager.Services 
{ 
    public class CsvExportService 
    { 
        { 
            lines.AddRange(orders.Select(o =
            await File.WriteAllLinesAsync(filePath, lines); 
            Console.WriteLine($"CSV exported to {filePath}"); 
        } 
    } 
} 
