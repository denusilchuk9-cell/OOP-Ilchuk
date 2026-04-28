using System;

namespace lab24v7
{
    public class ResultPublisher
    {
        public event Action<double, string> ResultCalculated;

        public void PublishResult(double result, string operationName)
        {
            if (ResultCalculated != null)
                ResultCalculated(result, operationName);
        }
    }
}