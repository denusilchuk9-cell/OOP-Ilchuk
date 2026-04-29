using System;
using System.Collections.Generic;

namespace CompositeDecoratorDemo.Composite
{
    public class Group : IGraphic
    {
        private List<IGraphic> _graphics = new List<IGraphic>();

        public void Add(IGraphic graphic)
        {
            _graphics.Add(graphic);
        }

        public void Remove(IGraphic graphic)
        {
            _graphics.Remove(graphic);
        }

        public void Draw()
        {
            Console.WriteLine("Drawing a Group:");
            foreach (var graphic in _graphics)
            {
                graphic.Draw();
            }
        }
    }
}