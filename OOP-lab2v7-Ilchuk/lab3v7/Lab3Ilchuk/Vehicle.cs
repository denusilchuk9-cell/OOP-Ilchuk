using System;

namespace Lab3Ilchuk
{
    public class Vehicle
    {
        protected string Brand;
        protected int Year;

        public Vehicle(string brand, int year)
        {
            Brand = brand;
            Year = year;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Базовий транспорт: Бренд = {Brand}, Рік = {Year}");
        }
    }
}