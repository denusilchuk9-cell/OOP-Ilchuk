using System;

namespace Lab3Ilchuk
{
    // Клас Square, що успадковується від Figure
    public class Square : Figure
    {
        // Конструктор класу Square
        public Square(double side) : base(side) { }

        // Перевизначений метод для виведення інформації про квадрат
        public override void Describe()
        {
            base.Describe(); // Виклик методу базового класу
            double area = CalculateProperty(); // Обчислення площі
            Console.WriteLine($"Квадрат: Площа = {area}");
        }

        // Перевизначений абстрактний метод для обчислення площі
        public override double CalculateProperty()
        {
            return Side * Side;
        }

        // Деструктор для вивільнення ресурсів (демонстрація)
        ~Square()
        {
            Console.WriteLine($"Деструктор Square для сторони {Side} викликано.");
        }
    }
}