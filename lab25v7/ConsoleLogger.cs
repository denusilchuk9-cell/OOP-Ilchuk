using System;

namespace lab25
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[ConsoleLogger] {message}");
        }
    }
}