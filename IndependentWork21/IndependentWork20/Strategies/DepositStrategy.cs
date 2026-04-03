using System;

namespace IndependentWork20.Strategies
{
    public class DepositStrategy : ITransactionStrategy
    {
        public string Process(decimal amount, string accountId)
        {
            if (amount <= 0)
            {
                return $"ERROR: Amount {amount:C} is invalid for account {accountId}";
            }

            return $"DEPOSIT:{amount}:{accountId}";
        }
    }
}