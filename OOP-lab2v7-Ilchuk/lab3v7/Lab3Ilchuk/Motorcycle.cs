using System;

namespace Lab3Ilchuk
{
    // Клас Motorcycle, що успадковується від Vehicle
    public class Motorcycle : Vehicle
    {
        // Приватне поле для зберігання інформації про наявність коляски
        private bool HasSidecar;

        // Конструктор класу Motorcycle
        // Приймає brand - бренд, year - рік випуску, hasSidecar - наявність коляски
        public Motorcycle(string brand, int year, bool hasSidecar) : base(brand, year)
        {
            HasSidecar = hasSidecar;
        }

        // Перевизначений метод для виведення інформації про мотоцикл
        public override void DisplayInfo()
        {
            base.DisplayInfo(); // Виклик методу базового класу
            Console.WriteLine($"Мотоцикл: Має коляску = {(HasSidecar ? "Так" : "Ні")}");
        }
    }
}