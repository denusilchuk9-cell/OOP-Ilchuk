using System;

namespace lab23
{
    public class WordDocumentProcessor : IDocumentProcessor
    {
        public void Read(string filePath)
        {
            Console.WriteLine($"Reading Word document: {filePath}");
        }

        public void Write(string filePath, string content)
        {
            Console.WriteLine($"Writing to Word document: {filePath}");
        }

        public void Print(string filePath)
        {
            Console.WriteLine($"Printing Word document: {filePath}");
        }

        public void ConvertToPdf(string filePath)
        {
            Console.WriteLine($"Converting Word to PDF: {filePath}");
        }

        public void ConvertToWord(string filePath)
        {
            Console.WriteLine($"Converting to Word format: {filePath}");
        }
    }
}