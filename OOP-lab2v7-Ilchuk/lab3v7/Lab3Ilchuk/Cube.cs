using System;

namespace Lab3Ilchuk
{
    // Клас Cube, що успадковується від Figure
    public class Cube : Figure
    {
        // Конструктор класу Cube
        // Приймає параметр side - довжина ребра куба
        public Cube(double side) : base(side) { }

        // Перевизначений метод для виведення інформації про куб
        public override void Describe()
        {
            base.Describe(); // Виклик методу базового класу
            double volume = Side * Side * Side; // Обчислення об'єму куба
            Console.WriteLine($"Куб: Об'єм = {volume}");
        }
    }
}