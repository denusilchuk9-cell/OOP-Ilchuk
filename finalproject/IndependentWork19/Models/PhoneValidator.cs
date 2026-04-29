using System;
using System.Linq;

namespace IndependentWork19.Models
{
    public class PhoneValidator : IValidator
    {
        private string _errorMessage;

        public bool Validate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                _errorMessage = "Phone number cannot be empty";
                return false;
            }

            string cleaned = new string(input.Where(c => char.IsDigit(c)).ToArray());

            if (cleaned.Length < 10 || cleaned.Length > 13)
            {
                _errorMessage = "Phone number must contain 10-13 digits";
                return false;
            }

            if (!cleaned.StartsWith("380") && cleaned.Length == 12)
            {
                _errorMessage = "Ukrainian phone number must start with 380";
                return false;
            }

            _errorMessage = string.Empty;
            Console.WriteLine($"[PHONE VALIDATOR] Validating: {input} - SUCCESS");
            return true;
        }

        public string GetErrorMessage()
        {
            return string.IsNullOrEmpty(_errorMessage)
                ? "Phone number is valid"
                : _errorMessage;
        }
    }
}