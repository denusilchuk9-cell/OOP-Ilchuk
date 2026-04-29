using System;

namespace IndependentWork16
{
    public class ImageProcessor
    {
        private readonly IImageLoader _imageLoader;
        private readonly IImageValidator _imageValidator;
        private readonly IImageResizer _imageResizer;
        private readonly IImageFilter _imageFilter;
        private readonly IImageSaver _imageSaver;
        private readonly ILogger _logger;
        private readonly INotificationService _notificationService;

        // Dependency Injection через конструктор
        public ImageProcessor(
            IImageLoader imageLoader,
            IImageValidator imageValidator,
            IImageResizer imageResizer,
            IImageFilter imageFilter,
            IImageSaver imageSaver,
            ILogger logger,
            INotificationService notificationService)
        {
            _imageLoader = imageLoader;
            _imageValidator = imageValidator;
            _imageResizer = imageResizer;
            _imageFilter = imageFilter;
            _imageSaver = imageSaver;
            _logger = logger;
            _notificationService = notificationService;
        }

        public bool ProcessImage(
            string inputPath,
            string outputPath,
            int width,
            int height,
            string filterType)
        {
            Console.WriteLine("\n=== Обробка зображення (рефакторинг) ===");

            try
            {
                // 1. Завантаження
                _logger.Log("Початок завантаження зображення");
                var imageData = _imageLoader.LoadImage(inputPath);

                // 2. Валідація
                _logger.Log("Валідація зображення");
                if (!_imageValidator.Validate(imageData))
                {
                    _logger.Log("Помилка: невалідне зображення");
                    return false;
                }

                // 3. Зміна розміру
                _logger.Log("Зміна розміру зображення");
                imageData = _imageResizer.Resize(imageData, width, height);

                // 4. Застосування фільтра
                _logger.Log("Застосування фільтра");
                imageData = _imageFilter.ApplyFilter(imageData, filterType);

                // 5. Збереження
                _logger.Log("Збереження зображення");
                _imageSaver.SaveImage(imageData, outputPath);

                // 6. Сповіщення
                _notificationService.SendNotification(
                    $"Зображення успішно оброблено та збережено до {outputPath}");

                _logger.Log("Обробка зображення завершена успішно");
                return true;
            }
            catch (Exception ex)
            {
                _logger.Log($"Помилка при обробці зображення: {ex.Message}");
                return false;
            }
        }
    }
}