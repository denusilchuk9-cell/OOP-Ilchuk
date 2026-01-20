using ConsoleApp5.Strategies;

namespace ConsoleApp5.Services
{
    public class CloudStorageService
    {
        private readonly IStoragePricingStrategy _strategy;

        public CloudStorageService(IStoragePricingStrategy strategy)
        {
            _strategy = strategy;
        }

        public decimal Calculate(decimal storageGb, int users)
        {
            return _strategy.CalculateCost(storageGb, users);
        }
    }
}
