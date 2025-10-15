using System;

namespace Lab3Ilchuk
{
    // Клас Cube, що успадковується від Figure
    public class Cube : Figure
    {
        // Конструктор класу Cube
        public Cube(double side) : base(side) { }

        // Перевизначений метод для виведення інформації про куб
        public override void Describe()
        {
            base.Describe(); // Виклик методу базового класу
            double volume = CalculateProperty(); // Обчислення об'єму
            Console.WriteLine($"Куб: Об'єм = {volume}");
        }

        // Перевизначений абстрактний метод для обчислення об'єму
        public override double CalculateProperty()
        {
            return Side * Side * Side;
        }

        // Деструктор для вивільнення ресурсів (демонстрація)
        ~Cube()
        {
            Console.WriteLine($"Деструктор Cube для сторони {Side} викликано.");
        }
    }
}