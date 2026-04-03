using IndependentWork19.Models;
using IndependentWork19.Factories;

namespace IndependentWork19.Factories
{
    public class EmailValidatorFactory : ValidatorFactory
    {
        public override IValidator CreateValidator()
        {
            return new EmailValidator();
        }
    }
}