using System;
using IndependentWork19.Factories;

namespace IndependentWork19.Services
{
    public sealed class ValidationService
    {
        private static ValidationService _instance;
        private static readonly object _lock = new object();
        private ValidatorFactory _currentFactory;

        private ValidationService()
        {
            Console.WriteLine("[SINGLETON] ValidationService instance created");
        }

        public static ValidationService GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ValidationService();
                    }
                }
            }
            return _instance;
        }

        public void SetValidatorFactory(ValidatorFactory factory)
        {
            _currentFactory = factory;
            string factoryName = factory.GetType().Name;
            Console.WriteLine($"\n[FACTORY CHANGED] Now using: {factoryName}");
        }

        public void Validate(string input)
        {
            if (_currentFactory == null)
            {
                Console.WriteLine("ERROR: No validator factory set. Please call SetValidatorFactory first.");
                return;
            }

            Console.WriteLine($"\n--- Validating: \"{input}\" ---");
            _currentFactory.ValidateMessage(input);
        }
    }
}