using System;

namespace lab31v7;

public interface ITokenGenerator
{
    string GenerateToken(int userId, string email);
    bool ValidateToken(string token);
}