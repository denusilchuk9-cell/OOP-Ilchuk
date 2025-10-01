using System;

namespace Lab3Ilchuk
{
    public class Cube : Figure
    {
        public Cube(double side) : base(side) { }

        public override void Describe()
        {
            base.Describe();
            double volume = Side * Side * Side;
            Console.WriteLine($"Куб: Об'єм = {volume}");
        }
    }
}