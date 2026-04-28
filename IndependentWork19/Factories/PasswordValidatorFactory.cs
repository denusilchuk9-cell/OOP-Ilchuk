using IndependentWork19.Models;
using IndependentWork19.Factories;

namespace IndependentWork19.Factories
{
    public class PasswordValidatorFactory : ValidatorFactory
    {
        public override IValidator CreateValidator()
        {
            return new PasswordValidator();
        }
    }
}