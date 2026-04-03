using System;

namespace CompositeDecoratorDemo.Composite
{
    public class Rectangle : IGraphic
    {
        public void Draw()
        {
            Console.WriteLine("Drawing a Rectangle");
        }
    }
}