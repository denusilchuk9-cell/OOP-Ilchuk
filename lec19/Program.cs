using CompositeDecoratorDemo.Composite;
using CompositeDecoratorDemo.Decorator;
using System;

namespace CompositeDecoratorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Composite Pattern Demo ===\n");

            IGraphic circle1 = new Circle();
            IGraphic rectangle1 = new Rectangle();

            Group group1 = new Group();
            group1.Add(circle1);
            group1.Add(rectangle1);

            IGraphic circle2 = new Circle();
            Group group2 = new Group();
            group2.Add(circle2);
            group2.Add(group1);

            group2.Draw();

            Console.WriteLine("\n=== Decorator Pattern Demo ===\n");

            ICoffee coffee = new SimpleCoffee();
            Console.WriteLine($"{coffee.GetDescription()} - ${coffee.GetCost():F2}");

            coffee = new MilkDecorator(coffee);
            Console.WriteLine($"{coffee.GetDescription()} - ${coffee.GetCost():F2}");

            coffee = new SugarDecorator(coffee);
            Console.WriteLine($"{coffee.GetDescription()} - ${coffee.GetCost():F2}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}