using System;

namespace IndependentWork16
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Демонстрація принципу єдиної відповідальності (SRP) ===\n");

            // Демонстрація "поганого" класу
            Console.WriteLine("1. Демонстрація 'поганого' класу (порушення SRP):");
            var badProcessor = new BadImageProcessor("input.jpg");
            badProcessor.ProcessImage("output_bad.jpg", 800, 600, "Sepia");

            Console.WriteLine("\n" + new string('=', 60) + "\n");

            // Демонстрація рефакторингового класу
            Console.WriteLine("2. Демонстрація рефакторингової структури (дотримання SRP):");

            // Створення залежностей
            var imageLoader = new FileImageLoader();
            var imageValidator = new ImageValidator();
            var imageResizer = new ImageResizer();
            var imageFilter = new ImageFilter();
            var imageSaver = new FileImageSaver();
            var logger = new ConsoleLogger();
            var notificationService = new EmailNotificationService();

            // Створення ImageProcessor з ін'єкцією залежностей
            var goodProcessor = new ImageProcessor(
                imageLoader,
                imageValidator,
                imageResizer,
                imageFilter,
                imageSaver,
                logger,
                notificationService
            );

            // Виклик методу обробки
            bool result = goodProcessor.ProcessImage(
                "input.jpg",
                "output_good.jpg",
                800,
                600,
                "Sepia"
            );

            Console.WriteLine($"\nРезультат обробки: {(result ? "Успішно" : "Не успішно")}");

            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("Переваги рефакторингової структури:");
            Console.WriteLine("1. Кожен клас має одну відповідальність");
            Console.WriteLine("2. Легше тестувати окремі компоненти");
            Console.WriteLine("3. Можна легко заміняти реалізації (напр., інший логер)");
            Console.WriteLine("4. Код більш читабельний та підтримуваний");

            Console.ReadKey();
        }
    }
}