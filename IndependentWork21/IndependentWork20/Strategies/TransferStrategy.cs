namespace IndependentWork20.Strategies
{
    public class TransferStrategy : ITransactionStrategy
    {
        private string _targetAccount;

        public TransferStrategy(string targetAccount)
        {
            _targetAccount = targetAccount;
        }

        public string Process(decimal amount, string accountId)
        {
            if (amount <= 0)
            {
                return $"ERROR: Amount {amount:C} is invalid";
            }

            return $"TRANSFER:{amount}:{accountId}:{_targetAccount}";
        }
    }
}