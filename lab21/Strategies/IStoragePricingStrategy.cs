namespace ConsoleApp5.Strategies
{
    public interface IStoragePricingStrategy
    {
        decimal CalculateCost(decimal storageGb, int users);
    }
}
