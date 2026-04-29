using System;

namespace lab30v7;

public class CartItem
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public CartItem(string name, decimal price, int quantity)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Price = price >= 0 ? price : throw new ArgumentException("Price must be non-negative");
        Quantity = quantity > 0 ? quantity : throw new ArgumentException("Quantity must be positive");
    }
}