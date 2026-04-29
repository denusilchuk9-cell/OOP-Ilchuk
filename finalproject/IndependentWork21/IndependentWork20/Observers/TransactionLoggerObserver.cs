using IndependentWork20.Publisher;
using System;
using System.Collections.Generic;

namespace IndependentWork20.Observers
{
    public class TransactionLoggerObserver : ITransactionObserver
    {
        private List<string> _logs = new List<string>();

        public void OnTransactionProcessed(string transactionType, decimal amount, string accountId)
        {
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {transactionType}: {amount:C} | Account: {accountId}";
            _logs.Add(logEntry);
        }

        public List<string> GetLogs()
        {
            return _logs;
        }

        public void ClearLogs()
        {
            _logs.Clear();
        }
    }
}