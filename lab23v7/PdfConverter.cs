using System;

namespace lab23
{
    public class PdfConverter : IFileConverter
    {
        public void Convert(string sourcePath, string targetFormat)
        {
            Console.WriteLine($"Converting {sourcePath} to {targetFormat}");
        }
    }
}