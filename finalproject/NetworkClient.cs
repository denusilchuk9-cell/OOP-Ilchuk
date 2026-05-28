using System;
using System.Collections.Generic;
using System.Net.Http;

public class NetworkClient
{
    private int _attemptCount = 0;

    public List<string> GetUsersFromApi(string url)
    {
        _attemptCount++;
        if (_attemptCount <= 2)
        {
            throw new HttpRequestException($"Simulated HttpRequestException on attempt {_attemptCount}");
        }
        // Успішне виконання після 2 невдалих спроб
        return new List<string> { "apiUser1", "apiUser2", "apiUser3" };
    }
}