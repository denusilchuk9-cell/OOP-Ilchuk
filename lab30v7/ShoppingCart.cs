using System;
using System.Collections.Generic;
using System.Linq;

namespace lab30v7;

public class ShoppingCart
{
    private readonly List<CartItem> _items = new List<CartItem>();

    public void AddItem(CartItem item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        var existing = _items.FirstOrDefault(i => i.Name == item.Name);
        if (existing != null)
        {
            existing.Quantity += item.Quantity;
        }
        else
        {
            _items.Add(item);
        }
    }

    public bool RemoveItem(string productName)
    {
        if (string.IsNullOrWhiteSpace(productName))
            throw new ArgumentException("Product name cannot be empty", nameof(productName));

        var item = _items.FirstOrDefault(i => i.Name == productName);
        if (item != null)
        {
            _items.Remove(item);
            return true;
        }
        return false;
    }

    public void Clear() => _items.Clear();

    public decimal CalculateTotal() => _items.Sum(i => i.Price * i.Quantity);

    public int ItemCount => _items.Count;
}