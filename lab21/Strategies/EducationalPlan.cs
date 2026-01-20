namespace ConsoleApp5.Strategies
{
    public class EducationalPlan : IStoragePricingStrategy
    {
        public decimal CalculateCost(decimal storageGb, int users)
        {
            return storageGb * 0.3m + users * 2;
        }
    }
}