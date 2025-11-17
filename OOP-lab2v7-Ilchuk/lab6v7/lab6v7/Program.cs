using System;
using System.Collections.Generic;
using System.Linq;

// === Власний делегат (арифметична операція) ===
delegate int Operation(int a, int b);

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("=== Lab 6: Lambda & Delegates ===\n");

        // --------------------------------------------------------------
        // 1. Використання власного делегата
        // --------------------------------------------------------------

        // АНОНІМНИЙ МЕТОД
        Operation add = delegate (int x, int y)
        {
            return x + y;
        };

        // ЛЯМБДА-ВИРАЗ
        Operation multiply = (x, y) => x * y;

        Console.WriteLine("Анонімний метод add(5,7) = " + add(5, 7));
        Console.WriteLine("Лямбда multiply(5,7) = " + multiply(5, 7));
        Console.WriteLine();


        // --------------------------------------------------------------
        // 2. Використання стандартних делегатів Func, Action, Predicate
        // --------------------------------------------------------------

        Func<int, int, int> subtract = (x, y) => x - y;  // Func
        Console.WriteLine("Func subtract(10,3) = " + subtract(10, 3));

        Action<string> printer = msg => Console.WriteLine("Повідомлення: " + msg); // Action
        printer("Приклад використання Action<>");

        Predicate<int> isEven = n => n % 2 == 0; // Predicate
        Console.WriteLine("Predicate isEven(4) = " + isEven(4));
        Console.WriteLine();


        // --------------------------------------------------------------
        // 3. Робота з колекцією + LINQ
        // --------------------------------------------------------------

        List<int> numbers = new List<int> { 5, 1, 7, 2, 8, 3, 9, 4 };

        var evenNumbers = numbers.Where(n => n % 2 == 0).OrderBy(n => n);

        Console.WriteLine("Парні числа (Where + OrderBy):");
        foreach (var n in evenNumbers)
            Console.Write(n + " ");
        Console.WriteLine("\n");

        var squaresSum = numbers.Select(n => n * n).Aggregate((a, b) => a + b);
        Console.WriteLine("Сума квадратів чисел (Select + Aggregate) = " + squaresSum);
        Console.WriteLine();


        // --------------------------------------------------------------
        // 4. TemperatureRecord + Func + Action
        // --------------------------------------------------------------

        List<TemperatureRecord> temps = new List<TemperatureRecord>
        {
            new TemperatureRecord("Понеділок", 22.5),
            new TemperatureRecord("Вівторок", 27.3),
            new TemperatureRecord("Середа", 29.1),
            new TemperatureRecord("Четвер", 18.4),
            new TemperatureRecord("Пʼятниця", 31.0)
        };

        // Func<double,bool> — перевірка >25°C
        Func<double, bool> isHot = t => t > 25.0;

        // Action<double> — вивід формату “Спекотно: X°C”
        Action<double> showHot = t =>
            Console.WriteLine($"Спекотно: {t}°C");

        Console.WriteLine("Дні зі спекотною температурою (>25°C):");

        var hotDays = temps.Where(t => isHot(t.Celsius));

        foreach (var day in hotDays)
            showHot(day.Celsius);

        Console.WriteLine("\nГотово!");
    }
}
