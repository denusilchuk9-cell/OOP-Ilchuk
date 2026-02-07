using System;

namespace lab23
{
    public class ExcelWriter : IFileWriter
    {
        public void Write(string filePath, string content)
        {
            Console.WriteLine($"Writing to Excel file: {filePath}, Data: {content}");
        }
    }
}