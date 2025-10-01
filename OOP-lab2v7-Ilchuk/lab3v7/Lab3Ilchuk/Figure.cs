using System;

namespace Lab3Ilchuk
{
    public class Figure
    {
        protected double Side;

        public Figure(double side)
        {
            Side = side;
        }

        public virtual void Describe()
        {
            Console.WriteLine($"Базова фігура: Сторона = {Side}");
        }
    }
}