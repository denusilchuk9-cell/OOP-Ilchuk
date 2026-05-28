namespace OrderManager 
{ 
    public class Order 
    { 
        public int Id { get; set; } 
        public string Product { get; set; } = string.Empty; 
        public int Quantity { get; set; } 
        public decimal Price { get; set; } 
 
        public string GetDisplayName() 
        { 
            return string.IsNullOrEmpty(Product) ? "No product" : Product; 
        } 
    } 
} 
