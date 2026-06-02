using System;
using System.Collections.Generic;
using System.IO;

public class FileProcessor
{
    private int _attemptCount = 0;

    public List<string> LoadUsernames(string path)
    {
        _attemptCount++;
        if (_attemptCount <= 3)
        {
            throw new IOException($"Simulated IOException on attempt {_attemptCount}");
        }
        // Успішне виконання після 3 невдалих спроб
        return new List<string> { "user1", "user2", "user3" };
    }
}