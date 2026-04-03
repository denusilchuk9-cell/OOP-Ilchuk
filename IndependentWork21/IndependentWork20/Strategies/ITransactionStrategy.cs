namespace IndependentWork20.Strategies
{
    public interface ITransactionStrategy
    {
        string Process(decimal amount, string accountId);
    }
}