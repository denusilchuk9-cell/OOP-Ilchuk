using System;

namespace IndependentWork16
{
    public interface IImageLoader
    {
        byte[] LoadImage(string imagePath);
    }

    public class FileImageLoader : IImageLoader
    {
        public byte[] LoadImage(string imagePath)
        {
            Console.WriteLine($"Завантаження зображення з: {imagePath}");
            return new byte[1024]; // Імітація даних
        }
    }
}