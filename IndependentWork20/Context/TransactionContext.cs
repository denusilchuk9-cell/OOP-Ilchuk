using IndependentWork20.Strategies;

namespace IndependentWork20.Context
{
    public class TransactionContext
    {
        private ITransactionStrategy _strategy;

        public TransactionContext(ITransactionStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(ITransactionStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ExecuteTransaction(decimal amount, string accountId)
        {
            _strategy.Process(amount, accountId);
        }
    }
}