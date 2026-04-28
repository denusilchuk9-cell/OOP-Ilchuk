using System;

namespace IndependentWork20.Strategies
{
    public class WithdrawStrategy : ITransactionStrategy
    {
        private decimal _currentBalance = 1000m;

        public string Process(decimal amount, string accountId)
        {
            if (amount <= 0)
            {
                return $"ERROR: Amount {amount:C} is invalid for account {accountId}";
            }

            if (amount > _currentBalance)
            {
                return $"ERROR: Insufficient funds for account {accountId}. Available: {_currentBalance:C}";
            }

            _currentBalance -= amount;
            return $"WITHDRAW:{amount}:{accountId}:{_currentBalance}";
        }
    }
}