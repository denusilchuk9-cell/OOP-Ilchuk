using System;

namespace lab23
{
    public class PdfReader : IFileReader
    {
        public void Read(string filePath)
        {
            Console.WriteLine($"Reading PDF document: {filePath}");
        }
    }
}