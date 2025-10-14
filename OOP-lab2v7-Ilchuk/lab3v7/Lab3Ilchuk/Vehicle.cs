using System;

namespace Lab3Ilchuk
{
    // Базовий клас для транспортних засобів
    public class Vehicle
    {
        // Захищені поля для зберігання бренду та року випуску
        protected string Brand;
        protected int Year;

        // Конструктор класу Vehicle
        // Приймає параметри brand - бренд транспорту, year - рік випуску
        public Vehicle(string brand, int year)
        {
            Brand = brand;
            Year = year;
        }

        // Віртуальний метод для виведення інформації про транспорт
        // Може бути перевизначений у похідних класах
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Базовий транспорт: Бренд = {Brand}, Рік = {Year}");
        }
    }
}