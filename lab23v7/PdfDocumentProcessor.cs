using System;

namespace lab23
{
    public class PdfDocumentProcessor : IDocumentProcessor
    {
        public void Read(string filePath)
        {
            Console.WriteLine($"Reading PDF document: {filePath}");
        }

        public void Write(string filePath, string content)
        {
            throw new NotImplementedException("PDF writing not supported");
        }

        public void Print(string filePath)
        {
            Console.WriteLine($"Printing PDF document: {filePath}");
        }

        public void ConvertToPdf(string filePath)
        {
            throw new NotImplementedException("PDF is already in PDF format");
        }

        public void ConvertToWord(string filePath)
        {
            Console.WriteLine($"Converting PDF to Word: {filePath}");
        }
    }
}