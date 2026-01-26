using System;

namespace IndependentWork16
{
    // "Поганий" клас, який порушує SRP
    public class BadImageProcessor
    {
        // Атрибути, що належать до різних відповідальностей
        private string _imagePath;
        private byte[] _imageData;

        // Конструктор
        public BadImageProcessor(string imagePath)
        {
            _imagePath = imagePath;
        }

        // Метод, який робить занадто багато - порушує SRP
        public void ProcessImage(string outputPath, int width, int height, string filterType)
        {
            Console.WriteLine("=== Обробка зображення (поганий приклад) ===");

            // 1. Завантаження зображення
            LoadImage();

            // 2. Валідація зображення
            if (!ValidateImage())
            {
                Console.WriteLine("Помилка: невалідне зображення!");
                return;
            }

            // 3. Зміна розміру
            ResizeImage(width, height);

            // 4. Застосування фільтра
            ApplyFilter(filterType);

            // 5. Збереження зображення
            SaveImage(outputPath);

            // 6. Логування
            LogProcessing();

            // 7. Відправка сповіщення
            SendNotification();
        }

        // Методи різних відповідальностей в одному класі

        private void LoadImage()
        {
            Console.WriteLine($"Завантаження зображення з: {_imagePath}");
            _imageData = new byte[1024]; // Імітація даних
        }

        private bool ValidateImage()
        {
            Console.WriteLine("Валідація зображення...");
            return _imageData != null && _imageData.Length > 0;
        }

        private void ResizeImage(int width, int height)
        {
            Console.WriteLine($"Зміна розміру зображення до: {width}x{height}");
        }

        private void ApplyFilter(string filterType)
        {
            Console.WriteLine($"Застосування фільтра: {filterType}");
        }

        private void SaveImage(string outputPath)
        {
            Console.WriteLine($"Збереження зображення до: {outputPath}");
        }

        private void LogProcessing()
        {
            Console.WriteLine("Логування процесу обробки...");
        }

        private void SendNotification()
        {
            Console.WriteLine("Відправка сповіщення про успішну обробку...");
        }
    }
}