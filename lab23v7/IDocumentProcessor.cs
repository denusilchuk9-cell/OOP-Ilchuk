namespace lab23
{
    public interface IDocumentProcessor
    {
        void Read(string filePath);
        void Write(string filePath, string content);
        void Print(string filePath);
        void ConvertToPdf(string filePath);
        void ConvertToWord(string filePath);
    }
}
