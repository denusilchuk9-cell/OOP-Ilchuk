using System;

namespace lab23
{
    public class ExcelReader : IFileReader
    {
        public void Read(string filePath)
        {
            Console.WriteLine($"Reading Excel file: {filePath}");
        }
    }
}