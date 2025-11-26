using Polly;
using Polly.CircuitBreaker;
using Polly.Timeout;
using System;
using System.Net.Http;
using System.Threading;

/// <summary>
/// Independent Work No11 – Polly Retry, Circuit Breaker, Timeout
/// </summary>
public class Program
{
    // ============================================================
    // SCENARIO 1 — External API retry
    // ============================================================
    private static int _apiAttempts = 0;

    public static string FakeExternalApi()
    {
        _apiAttempts++;

        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] API attempt {_apiAttempts}...");

        if (_apiAttempts <= 2)
            throw new HttpRequestException("Temporary API failure.");

        return "API response OK";
    }

    // ============================================================
    // SCENARIO 2 — Database Circuit Breaker
    // ============================================================
    private static int _dbAttempts = 0;

    public static string FakeDatabaseCall()
    {
        _dbAttempts++;

        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] DB attempt {_dbAttempts}...");

        if (_dbAttempts <= 3)
            throw new Exception("Database connection failed!");

        return "Database query OK";
    }

    // ============================================================
    // SCENARIO 3 — Long Operation with Timeout + Fallback
    // ============================================================
    public static string LongOperation()
    {
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Starting long operation...");
        Thread.Sleep(5000); // 5 seconds
        return "Operation completed normally";
    }

    // ============================================================
    // MAIN
    // ============================================================
    public static void Main(string[] args)
    {
        Console.WriteLine("\n===== SCENARIO 1: Retry Policy (External API) =====\n");

        var retryPolicy = Policy
            .Handle<HttpRequestException>()
            .WaitAndRetry(
                3,
                attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)),
                (exception, delay, attempt, context) =>
                {
                    Console.WriteLine(
                        $"Retry {attempt} after {delay.TotalSeconds}s: {exception.Message}"
                    );
                });

        try
        {
            string result = retryPolicy.Execute(() => FakeExternalApi());
            Console.WriteLine($"FINAL RESULT: {result}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Operation failed: {ex.Message}\n");
        }

        // --------------------------------------------------------

        Console.WriteLine("\n===== SCENARIO 2: Circuit Breaker (Database) =====\n");

        var circuitBreaker = Policy
            .Handle<Exception>()
            .CircuitBreaker(
                2,
                TimeSpan.FromSeconds(5),
                onBreak: (ex, ts) => Console.WriteLine($"Circuit OPEN for {ts.TotalSeconds}s"),
                onReset: () => Console.WriteLine("Circuit CLOSED — DB is working again"),
                onHalfOpen: () => Console.WriteLine("Circuit HALF-OPEN — testing DB...")
            );

        for (int i = 0; i < 6; i++)
        {
            try
            {
                string result = circuitBreaker.Execute(() => FakeDatabaseCall());
                Console.WriteLine($"DB RESULT: {result}");
            }
            catch (BrokenCircuitException)
            {
                Console.WriteLine("DB call skipped — circuit is OPEN");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DB error: {ex.Message}");
            }

            Thread.Sleep(1000);
        }

        // --------------------------------------------------------

        Console.WriteLine("\n===== SCENARIO 3: Timeout + Fallback =====\n");

        var timeoutPolicy = Policy
            .Timeout(2, TimeoutStrategy.Pessimistic, onTimeout: (context, time, task, ex) =>
            {
                Console.WriteLine($"TIMEOUT after {time.TotalSeconds}s!");
            });

        var fallbackPolicy = Policy<string>
            .Handle<TimeoutRejectedException>()
            .Fallback(
                fallbackAction: ct =>
                {
                    Console.WriteLine("Running fallback: returning cached value.");
                    return "Fallback result";
                });

        var combined = fallbackPolicy.Wrap(timeoutPolicy);

        string opResult = combined.Execute(() => LongOperation());
        Console.WriteLine($"FINAL RESULT: {opResult}");

        Console.WriteLine("\n===== END OF WORK =====");
    }
}
