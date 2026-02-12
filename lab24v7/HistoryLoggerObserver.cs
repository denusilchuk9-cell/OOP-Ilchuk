using System;
using System.Collections.Generic;

namespace lab24v7
{
    public class HistoryLoggerObserver
    {
        private readonly List<string> _history = new List<string>();

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
            string entry = $"{DateTime.Now:HH:mm:ss} - {operationName}: {result:F4}";
            _history.Add(entry);
        }

        public void PrintHistory()
        {
            Console.WriteLine("\n=== History Logger ===");
            foreach (var entry in _history)
            {
                Console.WriteLine(entry);
            }
        }

        public List<string> GetHistory()
        {
            return _history;
        }
    }
}