using System;

namespace Lab3Ilchuk
{
    // Клас Motorcycle, що успадковується від Vehicle
    public class Motorcycle : Vehicle
    {
        // Приватне поле
        private bool HasSidecar;

        // Конструктор класу Motorcycle
        public Motorcycle(string brand, int year, bool hasSidecar) : base(brand, year)
        {
            HasSidecar = hasSidecar;
        }

        // Перевизначений метод для виведення інформації
        public override void DisplayInfo()
        {
            base.DisplayInfo(); // Виклик методу базового класу
            Console.WriteLine($"Мотоцикл: Має коляску = {HasSidecar}");
        }

        // Перевизначений метод для обчислення витрат палива
        public override double CalculateFuelCost(double distance)
        {
            double fuelConsumption = 5.0; // Витрата 5 л/100 км
            return distance / 100.0 * fuelConsumption;
        }

        // Деструктор для вивільнення ресурсів
        ~Motorcycle()
        {
            Console.WriteLine($"Деструктор Motorcycle для {Brand} викликано.");
        }
    }
}