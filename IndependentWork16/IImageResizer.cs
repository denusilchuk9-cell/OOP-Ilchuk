using System;

namespace IndependentWork16
{
    public interface IImageResizer
    {
        byte[] Resize(byte[] imageData, int width, int height);
    }

    public class ImageResizer : IImageResizer
    {
        public byte[] Resize(byte[] imageData, int width, int height)
        {
            Console.WriteLine($"Зміна розміру зображення до: {width}x{height}");
            return imageData; // Імітація
        }
    }
}