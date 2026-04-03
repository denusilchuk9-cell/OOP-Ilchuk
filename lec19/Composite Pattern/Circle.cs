using System;

namespace CompositeDecoratorDemo.Composite
{
    public class Circle : IGraphic
    {
        public void Draw()
        {
            Console.WriteLine("Drawing a Circle");
        }
    }
}