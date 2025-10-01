using System;

namespace Lab3Ilchuk
{
    public class Car : Vehicle
    {
        private int Doors;

        public Car(string brand, int year, int doors) : base(brand, year)
        {
            Doors = doors;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Автомобіль: Кількість дверей = {Doors}");
        }
    }
}