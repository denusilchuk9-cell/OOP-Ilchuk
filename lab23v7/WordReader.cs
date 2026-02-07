using System;

namespace lab23
{
    public class WordReader : IFileReader
    {
        public void Read(string filePath)
        {
            Console.WriteLine($"Reading Word document: {filePath}");
        }
    }
}