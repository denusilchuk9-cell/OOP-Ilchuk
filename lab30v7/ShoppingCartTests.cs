using lab30v7;
using Xunit;

namespace lab30v7.Tests;

public class ShoppingCartTests
{
    [Fact]
    public void AddItem_NewItem_AddsToCart()
    {
        var cart = new ShoppingCart();
        var item = new CartItem("Apple", 1.5m, 2);

        cart.AddItem(item);

        Assert.Equal(1, cart.ItemCount);
        Assert.Equal(3.0m, cart.CalculateTotal());
    }

    [Fact]
    public void AddItem_DuplicateItem_IncreasesQuantity()
    {
        var cart = new ShoppingCart();
        var item1 = new CartItem("Apple", 1.5m, 2);
        var item2 = new CartItem("Apple", 1.5m, 3);

        cart.AddItem(item1);
        cart.AddItem(item2);

        Assert.Equal(1, cart.ItemCount);
        Assert.Equal(7.5m, cart.CalculateTotal());
    }

    [Fact]
    public void AddItem_NegativeQuantity_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new CartItem("Bad", 1.0m, -1));
    }

    [Fact]
    public void RemoveItem_ExistingItem_RemovesAndReturnsTrue()
    {
        var cart = new ShoppingCart();
        cart.AddItem(new CartItem("Apple", 1.0m, 1));

        bool removed = cart.RemoveItem("Apple");

        Assert.True(removed);
        Assert.Equal(0, cart.ItemCount);
        Assert.Equal(0, cart.CalculateTotal());
    }

    [Fact]
    public void RemoveItem_NonExistingItem_ReturnsFalse()
    {
        var cart = new ShoppingCart();

        bool removed = cart.RemoveItem("Orange");

        Assert.False(removed);
        Assert.Equal(0, cart.ItemCount);
    }

    [Fact]
    public void CalculateTotal_EmptyCart_ReturnsZero()
    {
        var cart = new ShoppingCart();

        decimal total = cart.CalculateTotal();

        Assert.Equal(0, total);
    }

    [Fact]
    public void CalculateTotal_MultipleItems_ReturnsCorrectSum()
    {
        var cart = new ShoppingCart();
        cart.AddItem(new CartItem("Apple", 1.5m, 2));
        cart.AddItem(new CartItem("Banana", 0.8m, 3));

        decimal total = cart.CalculateTotal();

        Assert.Equal(1.5m * 2 + 0.8m * 3, total);
    }

    [Fact]
    public void Clear_RemovesAllItems()
    {
        var cart = new ShoppingCart();
        cart.AddItem(new CartItem("Apple", 1.0m, 1));
        cart.AddItem(new CartItem("Banana", 2.0m, 1));

        cart.Clear();

        Assert.Equal(0, cart.ItemCount);
        Assert.Equal(0, cart.CalculateTotal());
    }

    [Theory]
    [InlineData("Apple", 1.5, 2, 3.0)]
    [InlineData("Orange", 2.0, 1, 2.0)]
    [InlineData("Grape", 0.75, 4, 3.0)]
    public void AddItem_WithVariousItems_CalculatesCorrectTotal(
        string name, decimal price, int quantity, decimal expectedTotal)
    {
        var cart = new ShoppingCart();

        cart.AddItem(new CartItem(name, price, quantity));

        Assert.Equal(1, cart.ItemCount);
        Assert.Equal(expectedTotal, cart.CalculateTotal());
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-5)]
    public void AddItem_InvalidQuantity_ThrowsArgumentException(int quantity)
    {
        Assert.Throws<ArgumentException>(() => new CartItem("Test", 10m, quantity));
    }

    [Theory]
    [InlineData("Apple", true, 0)]
    [InlineData("Banana", false, 1)]
    public void RemoveItem_TestCases(string productName, bool expectedResult, int expectedCount)
    {
        var cart = new ShoppingCart();
        cart.AddItem(new CartItem("Apple", 1.0m, 1));

        bool result = cart.RemoveItem(productName);

        Assert.Equal(expectedResult, result);
        Assert.Equal(expectedCount, cart.ItemCount);
    }
}