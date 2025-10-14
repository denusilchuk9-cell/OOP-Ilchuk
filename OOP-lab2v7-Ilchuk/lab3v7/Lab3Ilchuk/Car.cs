using System;

namespace Lab3Ilchuk
{
    // Клас Car, що успадковується від Vehicle
    public class Car : Vehicle
    {
        // Приватне поле
        private int Doors;

        // Конструктор класу Car
        public Car(string brand, int year, int doors) : base(brand, year)
        {
            Doors = doors;
        }

        // Перевизначений метод для виведення інформації
        public override void DisplayInfo()
        {
            base.DisplayInfo(); // Виклик методу базового класу
            Console.WriteLine($"Автомобіль: Кількість дверей = {Doors}");
        }

        // Перевизначений метод для обчислення витрат палива
        public override double CalculateFuelCost(double distance)
        {
            double fuelConsumption = 10.0; // Витрата 10 л/100 км
            return distance / 100.0 * fuelConsumption;
        }

        // Деструктор для вивільнення ресурсів
        ~Car()
        {
            Console.WriteLine($"Деструктор Car для {Brand} викликано.");
        }
    }
}