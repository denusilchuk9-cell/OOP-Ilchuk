namespace ConsoleApp5.Strategies
{
    public class BusinessPlan : IStoragePricingStrategy
    {
        public decimal CalculateCost(decimal storageGb, int users)
        {
            return storageGb * 0.8m + users * 5;
        }
    }
}
