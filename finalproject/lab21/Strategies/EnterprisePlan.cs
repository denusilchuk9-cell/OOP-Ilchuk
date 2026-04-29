namespace ConsoleApp5.Strategies
{
    public class EnterprisePlan : IStoragePricingStrategy
    {
        public decimal CalculateCost(decimal storageGb, int users)
        {
            return storageGb * 1.2m + users * 10 + 100;
        }
    }
}
