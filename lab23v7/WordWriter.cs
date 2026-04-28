using System;

namespace lab23
{
    public class WordWriter : IFileWriter
    {
        public void Write(string filePath, string content)
        {
            Console.WriteLine($"Writing to Word document: {filePath}");
        }
    }
}