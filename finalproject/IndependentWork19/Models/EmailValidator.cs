using System;

namespace IndependentWork19.Models
{
    public class EmailValidator : IValidator
    {
        private string _errorMessage;

        public bool Validate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                _errorMessage = "Email cannot be empty";
                return false;
            }

            if (!input.Contains("@") || !input.Contains("."))
            {
                _errorMessage = "Email must contain '@' and '.' characters";
                return false;
            }

            if (input.IndexOf('@') > input.LastIndexOf('.'))
            {
                _errorMessage = "Invalid email format: domain part missing after '@'";
                return false;
            }

            _errorMessage = string.Empty;
            Console.WriteLine($"[EMAIL VALIDATOR] Validating: {input} - SUCCESS");
            return true;
        }

        public string GetErrorMessage()
        {
            return string.IsNullOrEmpty(_errorMessage)
                ? "Email is valid"
                : _errorMessage;
        }
    }
}