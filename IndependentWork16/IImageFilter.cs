using System;

namespace IndependentWork16
{
    public interface IImageFilter
    {
        byte[] ApplyFilter(byte[] imageData, string filterType);
    }

    public class ImageFilter : IImageFilter
    {
        public byte[] ApplyFilter(byte[] imageData, string filterType)
        {
            Console.WriteLine($"Застосування фільтра: {filterType}");
            return imageData; // Імітація
        }
    }
}