using System;

namespace IndependentWork16
{
    public interface IImageValidator
    {
        bool Validate(byte[] imageData);
    }

    public class ImageValidator : IImageValidator
    {
        public bool Validate(byte[] imageData)
        {
            Console.WriteLine("Валідація зображення...");
            return imageData != null && imageData.Length > 0;
        }
    }
}