using System;

namespace lab24v7
{
    public class ThresholdNotifierObserver
    {
        private readonly double _threshold;

        public ThresholdNotifierObserver(double threshold)
        {
            _threshold = threshold;
        }

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
            if (result > _threshold)
            {
                Console.WriteLine($"[THRESHOLD] WARNING: Result {result:F4} from {operationName} exceeds threshold {_threshold:F4}!");
            }
        }
    }
}