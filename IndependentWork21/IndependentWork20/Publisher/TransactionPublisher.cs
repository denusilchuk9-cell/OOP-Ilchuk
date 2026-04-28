using System;
using System.Collections.Generic;

namespace IndependentWork20.Publisher
{
    public interface ITransactionObserver
    {
        void OnTransactionProcessed(string transactionType, decimal amount, string accountId);
    }

    public class TransactionPublisher
    {
        private List<ITransactionObserver> _observers = new List<ITransactionObserver>();

        public void Attach(ITransactionObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(ITransactionObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(string transactionType, decimal amount, string accountId)
        {
            foreach (var observer in _observers)
            {
                observer.OnTransactionProcessed(transactionType, amount, accountId);
            }
        }

        public void PublishTransaction(string transactionType, decimal amount, string accountId)
        {
            Notify(transactionType, amount, accountId);
        }
    }
}