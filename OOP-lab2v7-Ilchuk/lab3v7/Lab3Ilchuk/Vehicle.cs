using System;

namespace Lab3Ilchuk
{
    // Базовий клас для транспортних засобів
    public class Vehicle
    {
        // Захищені поля
        protected string Brand;
        protected int Year;

        // Конструктор класу Vehicle
        public Vehicle(string brand, int year)
        {
            Brand = brand;
            Year = year;
        }

        // Віртуальний метод для виведення інформації
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Базовий транспорт: Бренд = {Brand}, Рік = {Year}");
        }

        // Віртуальний метод для обчислення витрат палива
        public virtual double CalculateFuelCost(double distance)
        {
            return 0.0; // Базова реалізація
        }
    }
}