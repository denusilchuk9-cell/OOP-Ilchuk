using System;

namespace Lab3Ilchuk
{
    // Клас Car, що успадковується від Vehicle
    public class Car : Vehicle
    {
        // Приватне поле для зберігання кількості дверей
        private int Doors;

        // Конструктор класу Car
        // Приймає brand - бренд, year - рік випуску, doors - кількість дверей
        public Car(string brand, int year, int doors) : base(brand, year)
        {
            Doors = doors;
        }

        // Перевизначений метод для виведення інформації про автомобіль
        public override void DisplayInfo()
        {
            base.DisplayInfo(); // Виклик методу базового класу
            Console.WriteLine($"Автомобіль: Кількість дверей = {Doors}");
        }
    }
}