using System;
using System.Threading;

public static class RetryHelper
{
    public static T ExecuteWithRetry<T>(Func<T> operation, int retryCount = 3, TimeSpan initialDelay = default, Func<Exception, bool> shouldRetry = null)
    {
        int attempt = 0;
        TimeSpan delay = initialDelay == default ? TimeSpan.FromSeconds(1) : initialDelay; // За замовчуванням 1 секунда

        while (true)
        {
            try
            {
                attempt++;
                Console.WriteLine($"Attempt {attempt}...");
                return operation();
            }
            catch (Exception ex)
            {
                if (attempt > retryCount || (shouldRetry != null && !shouldRetry(ex)))
                {
                    Console.WriteLine($"Failed after {attempt} attempts. Throwing exception: {ex.Message}");
                    throw;
                }

                Console.WriteLine($"Retryable failure on attempt {attempt}: {ex.Message}");
                // Експоненційна затримка: initialDelay * 2^(attempt-1)
                TimeSpan currentDelay = TimeSpan.FromTicks(delay.Ticks * (long)Math.Pow(2, attempt - 1));
                Thread.Sleep(currentDelay);
            }
        }
    }
}