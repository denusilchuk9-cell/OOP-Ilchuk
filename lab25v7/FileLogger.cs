using System.IO;

namespace lab25
{
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            File.AppendAllText("log.txt", $"[FileLogger] {message}\n");
        }
    }
}