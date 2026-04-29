using System;
using IndependentWork19.Factories;
using IndependentWork19.Services;

namespace IndependentWork19
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Independent Work #19: Validation System ===\n");
            Console.WriteLine("Patterns: Factory Method + Singleton\n");

            ValidationService validator = ValidationService.GetInstance();

            Console.WriteLine("=== TEST 1: Email Validation ===");
            validator.SetValidatorFactory(new EmailValidatorFactory());
            validator.Validate("user@example.com");
            validator.Validate("invalid-email");
            validator.Validate("missing@domain");
            validator.Validate("");

            Console.WriteLine("\n=== TEST 2: Password Validation ===");
            validator.SetValidatorFactory(new PasswordValidatorFactory());
            validator.Validate("StrongP@ss123");
            validator.Validate("weak");
            validator.Validate("nouppercase123");
            validator.Validate("NOLOWERCASE123");
            validator.Validate("NoDigitsHere");

            Console.WriteLine("\n=== TEST 3: Phone Number Validation ===");
            validator.SetValidatorFactory(new PhoneValidatorFactory());
            validator.Validate("+380501234567");
            validator.Validate("12345");
            validator.Validate("0501234567");
            validator.Validate("+380991234567");
            validator.Validate("");

            Console.WriteLine("\n=== DEMONSTRATING SINGLETON ===");
            ValidationService anotherReference = ValidationService.GetInstance();
            Console.WriteLine($"Same instance? {ReferenceEquals(validator, anotherReference)}");
            Console.WriteLine($"Both references point to the same ValidationService object");

            Console.WriteLine("\n=== DEMONSTRATING FACTORY METHOD ===");
            Console.WriteLine("Each validator is created by its own factory:");
            Console.WriteLine("  - EmailValidator created by EmailValidatorFactory");
            Console.WriteLine("  - PasswordValidator created by PasswordValidatorFactory");
            Console.WriteLine("  - PhoneValidator created by PhoneValidatorFactory");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}