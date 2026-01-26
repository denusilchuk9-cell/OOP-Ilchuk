using System;

namespace IndependentWork16
{
    public interface IImageSaver
    {
        void SaveImage(byte[] imageData, string outputPath);
    }

    public class FileImageSaver : IImageSaver
    {
        public void SaveImage(byte[] imageData, string outputPath)
        {
            Console.WriteLine($"Збереження зображення до: {outputPath}");
        }
    }
}