using System;

namespace Lab3Ilchuk
{
    // Клас Square, що успадковується від Figure
    public class Square : Figure
    {
        // Конструктор класу Square
        // Приймає параметр side - довжина сторони квадрата
        public Square(double side) : base(side) { }

        // Перевизначений метод для виведення інформації про квадрат
        public override void Describe()
        {
            base.Describe(); // Виклик методу базового класу
            double area = Side * Side; // Обчислення площі квадрата
            Console.WriteLine($"Квадрат: Площа = {area}");
        }
    }
}