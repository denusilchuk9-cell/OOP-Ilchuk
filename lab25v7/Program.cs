using System;

namespace lab25
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("Лабораторна робота №25");
            Console.WriteLine("Тема: Інтеграція патернів (Factory, Singleton, Strategy, Observer)");
            Console.WriteLine("==========================================\n");

            // СЦЕНАРІЙ 1: Повна інтеграція
            Console.WriteLine("=== СЦЕНАРІЙ 1: Повна інтеграція ===\n");

            LoggerManager.Instance.SetLoggerFactory(new ConsoleLoggerFactory());
            LoggerManager.Instance.Log("Систему ініціалізовано");

            DataContext context = new DataContext(new EncryptDataStrategy());
            DataPublisher publisher = new DataPublisher();
            ProcessingLoggerObserver observer = new ProcessingLoggerObserver();

            publisher.DataProcessed += observer.OnDataProcessed;

            string data1 = "Secret Data 123";
            LoggerManager.Instance.Log($"Початкові дані: {data1}");

            string processed1 = context.ProcessData(data1);
            LoggerManager.Instance.Log($"Оброблені дані: {processed1}");

            publisher.PublishDataProcessed(processed1);

            Console.WriteLine("\n=== СЦЕНАРІЙ 2: Динамічна зміна логера ===\n");

            LoggerManager.Instance.SetLoggerFactory(new FileLoggerFactory());
            LoggerManager.Instance.Log("Логер змінено на FileLogger");

            string data2 = "Another Secret Data 456";
            Console.WriteLine($"[Console] Початкові дані: {data2}");

            string processed2 = context.ProcessData(data2);
            LoggerManager.Instance.Log($"Оброблені дані: {processed2}");

            publisher.PublishDataProcessed(processed2);

            Console.WriteLine("\n=== СЦЕНАРІЙ 3: Динамічна зміна стратегії ===\n");

            context.SetStrategy(new CompressDataStrategy());
            LoggerManager.Instance.Log("Стратегію змінено на CompressDataStrategy");

            string data3 = "Very Long Data That Needs Compression For Sure";
            Console.WriteLine($"[Console] Початкові дані: {data3}");

            string processed3 = context.ProcessData(data3);
            LoggerManager.Instance.Log($"Оброблені дані: {processed3}");

            publisher.PublishDataProcessed(processed3);

            Console.WriteLine("\n==========================================");
            Console.WriteLine("Всі сценарії успішно виконано!");
            Console.WriteLine("Перевірте файл log.txt для підтвердження роботи FileLogger");
            Console.WriteLine("==========================================");

            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}