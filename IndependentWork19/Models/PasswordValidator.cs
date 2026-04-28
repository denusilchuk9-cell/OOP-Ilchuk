using System;
using System.Linq;

namespace IndependentWork19.Models
{
    public class PasswordValidator : IValidator
    {
        private string _errorMessage;

        public bool Validate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                _errorMessage = "Password cannot be empty";
                return false;
            }

            if (input.Length < 8)
            {
                _errorMessage = "Password must be at least 8 characters long";
                return false;
            }

            if (!input.Any(char.IsUpper))
            {
                _errorMessage = "Password must contain at least one uppercase letter";
                return false;
            }

            if (!input.Any(char.IsLower))
            {
                _errorMessage = "Password must contain at least one lowercase letter";
                return false;
            }

            if (!input.Any(char.IsDigit))
            {
                _errorMessage = "Password must contain at least one digit";
                return false;
            }

            _errorMessage = string.Empty;
            Console.WriteLine($"[PASSWORD VALIDATOR] Validating: [HIDDEN] - SUCCESS");
            return true;
        }

        public string GetErrorMessage()
        {
            return string.IsNullOrEmpty(_errorMessage)
                ? "Password is valid"
                : _errorMessage;
        }
    }
}