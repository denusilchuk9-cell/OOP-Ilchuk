using System;
using System.Collections.Generic;

namespace Lab3Ilchuk
{
    // Головний клас програми
    class Program
    {
        // Точка входу в програму
        static void Main(string[] args)
        {
            // Створення об'єкта автомобіля
            Car myCar = new Car("Toyota", 2020, 4);
            // Створення об'єкта мотоцикла
            Motorcycle myMoto = new Motorcycle("Harley", 2018, true);

            // Створення списку транспортних засобів для демонстрації поліморфізму
            List<Vehicle> vehicles = new List<Vehicle>
            {
                myCar,
                myMoto
            };

            // Виведення інформації про транспортні засоби
            Console.WriteLine("Демонстрація поліморфізму:");
            foreach (Vehicle vehicle in vehicles)
            {
                vehicle.DisplayInfo();
                Console.WriteLine();
            }

            // Домашнє завдання: демонстрація поліморфізму для фігур
            Console.WriteLine("\nДомашнє завдання: Поліморфізм фігур");
            // Створення списку геометричних фігур
            List<Figure> figures = new List<Figure>
            {
                new Square(5),
                new Cube(3)
            };

            // Виведення інформації про фігури
            foreach (Figure fig in figures)
            {
                fig.Describe();
                Console.WriteLine();
            }

            // Очікування натискання клавіші для завершення програми
            Console.ReadKey();
        }
    }
}