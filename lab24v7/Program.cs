using System;
using System.Collections.Generic;

namespace lab24v7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Lab24: Strategy + Observer Pattern Demonstration ===\n");

            // Створюємо стратегії
            var squareStrategy = new SquareOperationStrategy();
            var cubeStrategy = new CubeOperationStrategy();
            var sqrtStrategy = new SquareRootOperationStrategy();

            // Створюємо процессор з початковою стратегією
            var processor = new NumericProcessor(squareStrategy);

            // Створюємо publisher
            var publisher = new ResultPublisher();

            // Створюємо спостерігачів
            var consoleLogger = new ConsoleLoggerObserver();
            var historyLogger = new HistoryLoggerObserver();
            var thresholdNotifier = new ThresholdNotifierObserver(25.0); // Виправлено назву

            // Підписуємо спостерігачів
            consoleLogger.Subscribe(publisher);
            historyLogger.Subscribe(publisher);
            thresholdNotifier.Subscribe(publisher);

            // Тестові дані
            double[] testData = new double[] { 4, 5, 9, 16 };

            // 1. Квадрат числа
            Console.WriteLine("Processing with Square Strategy:");
            foreach (var number in testData)
            {
                double result = processor.Process(number);
                publisher.PublishResult(result, "Square");
            }

            // 2. Куб числа
            Console.WriteLine("\nProcessing with Cube Strategy:");
            processor.SetStrategy(cubeStrategy);
            foreach (var number in testData)
            {
                double result = processor.Process(number);
                publisher.PublishResult(result, "Cube");
            }

            // 3. Квадратний корінь
            Console.WriteLine("\nProcessing with Square Root Strategy:");
            processor.SetStrategy(sqrtStrategy);
            foreach (var number in testData)
            {
                double result = processor.Process(number);
                publisher.PublishResult(result, "SquareRoot");
            }

            // Показуємо історію
            historyLogger.PrintHistory();

            // Демонстрація відписки
            Console.WriteLine("\nDemonstrating observer unsubscription:");
            consoleLogger.Unsubscribe(publisher);
            Console.WriteLine("[ConsoleLogger] Unsubscribed - further results will not be logged to console");

            // Додаткова обробка після відписки
            Console.WriteLine("\nProcessing additional number with Square Strategy:");
            processor.SetStrategy(squareStrategy);
            double extraResult = processor.Process(10);
            publisher.PublishResult(extraResult, "Square");

            // Показуємо оновлену історію
            historyLogger.PrintHistory();

            Console.WriteLine("\nDemonstration completed successfully!");
            Console.ReadKey();
        }
    }
}