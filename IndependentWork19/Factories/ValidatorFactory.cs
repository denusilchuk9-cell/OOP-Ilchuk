using IndependentWork19.Models;
using System;

namespace IndependentWork19.Factories
{
    public abstract class ValidatorFactory
    {
        public abstract IValidator CreateValidator();

        public void ValidateMessage(string input)
        {
            IValidator validator = CreateValidator();
            bool isValid = validator.Validate(input);

            if (!isValid)
            {
                Console.WriteLine($"  ERROR: {validator.GetErrorMessage()}");
            }
        }
    }
}