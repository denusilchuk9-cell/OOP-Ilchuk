using System;

namespace Lab3Ilchuk
{
    // Абстрактний базовий клас для геометричних фігур
    public abstract class Figure
    {
        // Захищене поле для зберігання довжини сторони
        protected double Side;

        // Конструктор класу Figure
        public Figure(double side)
        {
            Side = side;
        }

        // Віртуальний метод для виведення інформації про фігуру
        public virtual void Describe()
        {
            Console.WriteLine($"Базова фігура: Сторона = {Side}");
        }

        // Абстрактний метод для обчислення властивості (повинен бути перевизначений)
        public abstract double CalculateProperty();
    }
}