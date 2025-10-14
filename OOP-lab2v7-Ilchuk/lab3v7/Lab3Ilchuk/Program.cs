using System;
using System.Collections.Generic;

namespace Lab3Ilchuk
{
    class Program
    {
        static void Main(string[] args)
        {
            // Основна частина: Транспорт
            Car myCar = new Car("Toyota", 2020, 4);
            Motorcycle myMoto = new Motorcycle("Harley", 2018, true);

            List<Vehicle> vehicles = new List<Vehicle>
            {
                myCar,
                myMoto
            };

            Console.WriteLine("Демонстрація поліморфізму:");
            foreach (Vehicle vehicle in vehicles)
            {
                vehicle.DisplayInfo();
                Console.WriteLine();
            }

            // Домашнє: Фігури
            Console.WriteLine("\nДомашнє завдання: Поліморфізм фігур");
            List<Figure> figures = new List<Figure>
            {
                new Square(5),
                new Cube(3)
            };

            foreach (Figure fig in figures)
            {
                fig.Describe();
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}