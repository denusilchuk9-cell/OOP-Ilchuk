using System.Collections.Generic;
using IndependentWork20.Publisher;

namespace IndependentWork20.Observers
{
    public class BalanceUpdateObserver : ITransactionObserver
    {
        private Dictionary<string, decimal> _balances = new Dictionary<string, decimal>();

        public void OnTransactionProcessed(string transactionType, decimal amount, string accountId)
        {
            if (!_balances.ContainsKey(accountId))
            {
                _balances[accountId] = 1000m;
            }

            decimal oldBalance = _balances[accountId];
            decimal newBalance = oldBalance;

            switch (transactionType)
            {
                case "DEPOSIT":
                    newBalance = oldBalance + amount;
                    break;
                case "WITHDRAW":
                    newBalance = oldBalance - amount;
                    break;
                case "TRANSFER":
                    newBalance = oldBalance - amount;
                    break;
            }

            _balances[accountId] = newBalance;
        }

        public decimal GetBalance(string accountId)
        {
            return _balances.ContainsKey(accountId) ? _balances[accountId] : 0;
        }
    }
}