using System;

namespace lab23
{
    public class PdfPrinter : IFilePrinter
    {
        public void Print(string filePath)
        {
            Console.WriteLine($"Printing PDF document: {filePath}");
        }
    }
}