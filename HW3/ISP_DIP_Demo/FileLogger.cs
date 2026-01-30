namespace DIP_Demo
{
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            File.AppendAllText("log.txt", $"File: {message}\n");
        }
    }
}