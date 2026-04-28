using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

class Program
{
    static void Main(string[] args)
    {
        // Ініціалізація
        var fileProcessor = new FileProcessor();
        var networkClient = new NetworkClient();

        // shouldRetry: Повторювати для IOException та HttpRequestException
        Func<Exception, bool> shouldRetry = ex =>
            ex is IOException || ex is HttpRequestException;

        // Демонстрація для FileProcessor
        Console.WriteLine("Demonstrating FileProcessor with Retry:");
        try
        {
            List<string> usernames = RetryHelper.ExecuteWithRetry(() => fileProcessor.LoadUsernames("fake/path.txt"), retryCount: 4, initialDelay: TimeSpan.FromSeconds(1), shouldRetry: shouldRetry);
            Console.WriteLine("Success! Usernames: " + string.Join(", ", usernames));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Final failure: " + ex.Message);
        }

        Console.WriteLine("\n");

        // Демонстрація для NetworkClient
        Console.WriteLine("Demonstrating NetworkClient with Retry:");
        try
        {
            List<string> apiUsers = RetryHelper.ExecuteWithRetry(() => networkClient.GetUsersFromApi("https://fakeapi.com"), retryCount: 3, initialDelay: TimeSpan.FromSeconds(1), shouldRetry: shouldRetry);
            Console.WriteLine("Success! API Users: " + string.Join(", ", apiUsers));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Final failure: " + ex.Message);
        }
    }
}