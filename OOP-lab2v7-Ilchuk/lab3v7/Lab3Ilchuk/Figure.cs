using System;

namespace Lab3Ilchuk
{
    // Базовий клас для геометричних фігур
    public class Figure
    {
        // Захищене поле для зберігання довжини сторони
        protected double Side;

        // Конструктор класу Figure
        // Приймає параметр side - довжина сторони фігури
        public Figure(double side)
        {
            Side = side;
        }

        // Віртуальний метод для виведення інформації про фігуру
        // Може бути перевизначений у похідних класах
        public virtual void Describe()
        {
            Console.WriteLine($"Базова фігура: Сторона = {Side}");
        }
    }
}