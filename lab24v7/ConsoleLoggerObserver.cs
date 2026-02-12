using System;

namespace lab24v7
{
    public class ConsoleLoggerObserver
    {
        public void Subscribe(ResultPublisher publisher)
        {
            publisher.ResultCalculated += OnResultCalculated;
        }

        public void Unsubscribe(ResultPublisher publisher)
        {
            publisher.ResultCalculated -= OnResultCalculated;
        }

        private void OnResultCalculated(double result, string operationName)
        {
            Console.WriteLine($"[ConsoleLogger] Operation: {operationName}, Result: {result:F4}");
        }
    }
}