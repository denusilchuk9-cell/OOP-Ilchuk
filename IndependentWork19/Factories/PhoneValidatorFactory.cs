using IndependentWork19.Models;
using IndependentWork19.Factories;

namespace IndependentWork19.Factories
{
    public class PhoneValidatorFactory : ValidatorFactory
    {
        public override IValidator CreateValidator()
        {
            return new PhoneValidator();
        }
    }
}