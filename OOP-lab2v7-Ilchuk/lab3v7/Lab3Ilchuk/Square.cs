using System;

namespace Lab3Ilchuk
{
    public class Square : Figure
    {
        public Square(double side) : base(side) { }

        public override void Describe()
        {
            base.Describe();
            double area = Side * Side;
            Console.WriteLine($"Квадрат: Площа = {area}");
        }
    }
}