namespace ConsoleApp5.Strategies
{
    public class PersonalPlan : IStoragePricingStrategy
    {
        public decimal CalculateCost(decimal storageGb, int users)
        {
            return storageGb * 0.5m;
        }
    }
}
