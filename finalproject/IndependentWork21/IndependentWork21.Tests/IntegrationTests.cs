using System;
using Xunit;
using IndependentWork20.Strategies;
using IndependentWork20.Context;
using IndependentWork20.Publisher;
using IndependentWork20.Observers;

namespace IndependentWork21.Tests
{
    public class IntegrationTests
    {
        [Fact]
        public void Test_Strategy_ChangeAtRuntime_CorrectBehavior()
        {
            var context = new TransactionContext(new DepositStrategy());

            string depositResult = context.ExecuteTransaction(500m, "UA001");
            Assert.Contains("DEPOSIT:500", depositResult);

            context.SetStrategy(new WithdrawStrategy());
            string withdrawResult = context.ExecuteTransaction(200m, "UA001");
            Assert.Contains("WITHDRAW:200", withdrawResult);

            context.SetStrategy(new TransferStrategy("UA002"));
            string transferResult = context.ExecuteTransaction(100m, "UA001");
            Assert.Contains("TRANSFER:100", transferResult);
        }

        [Fact]
        public void Test_Observer_Subscribers_ReceiveNotifications()
        {
            var publisher = new TransactionPublisher();
            var logger = new TransactionLoggerObserver();
            var balanceUpdater = new BalanceUpdateObserver();

            publisher.Attach(logger);
            publisher.Attach(balanceUpdater);

            publisher.PublishTransaction("DEPOSIT", 500m, "UA001");
            publisher.PublishTransaction("WITHDRAW", 200m, "UA001");

            Assert.Equal(2, logger.GetLogs().Count);
            Assert.Equal(1300m, balanceUpdater.GetBalance("UA001"));
        }

        [Fact]
        public void Test_StrategyAndObserverTogether_EndToEndScenario()
        {
            var publisher = new TransactionPublisher();
            var logger = new TransactionLoggerObserver();
            var balanceUpdater = new BalanceUpdateObserver();

            publisher.Attach(logger);
            publisher.Attach(balanceUpdater);

            var context = new TransactionContext(new DepositStrategy());

            string result1 = context.ExecuteTransaction(1000m, "UA010");
            publisher.PublishTransaction("DEPOSIT", 1000m, "UA010");

            context.SetStrategy(new WithdrawStrategy());
            string result2 = context.ExecuteTransaction(300m, "UA010");
            publisher.PublishTransaction("WITHDRAW", 300m, "UA010");

            Assert.Contains("DEPOSIT:1000", result1);
            Assert.Contains("WITHDRAW:300", result2);
            Assert.Equal(2, logger.GetLogs().Count);
            Assert.Equal(1700m, balanceUpdater.GetBalance("UA010"));
        }

        [Fact]
        public void Test_Negative_WithdrawMoreThanBalance_ReturnsError()
        {
            var context = new TransactionContext(new WithdrawStrategy());

            string result = context.ExecuteTransaction(1500m, "UA999");

            Assert.Contains("ERROR", result);
            Assert.Contains("Insufficient funds", result);
        }

        [Fact]
        public void Test_Negative_InvalidAmount_ReturnsError()
        {
            var context = new TransactionContext(new DepositStrategy());

            string result1 = context.ExecuteTransaction(-100m, "UA001");
            string result2 = context.ExecuteTransaction(0m, "UA001");

            Assert.Contains("ERROR", result1);
            Assert.Contains("ERROR", result2);
        }

        [Fact]
        public void Test_ObserverDetach_NoLongerReceivesNotifications()
        {
            var publisher = new TransactionPublisher();
            var logger = new TransactionLoggerObserver();

            publisher.Attach(logger);
            publisher.PublishTransaction("DEPOSIT", 100m, "UA001");
            Assert.Single(logger.GetLogs());

            publisher.Detach(logger);
            publisher.PublishTransaction("DEPOSIT", 200m, "UA001");
            Assert.Single(logger.GetLogs());
        }

        [Fact]
        public void Test_MultipleObservers_AllReceiveNotifications()
        {
            var publisher = new TransactionPublisher();
            var logger1 = new TransactionLoggerObserver();
            var logger2 = new TransactionLoggerObserver();
            var balanceUpdater = new BalanceUpdateObserver();

            publisher.Attach(logger1);
            publisher.Attach(logger2);
            publisher.Attach(balanceUpdater);

            publisher.PublishTransaction("DEPOSIT", 500m, "UA777");

            Assert.Single(logger1.GetLogs());
            Assert.Single(logger2.GetLogs());
            Assert.Equal(1500m, balanceUpdater.GetBalance("UA777"));
        }

        [Fact]
        public void Test_StrategyChain_DepositThenWithdrawThenTransfer()
        {
            var publisher = new TransactionPublisher();
            var balanceUpdater = new BalanceUpdateObserver();
            publisher.Attach(balanceUpdater);

            var context = new TransactionContext(new DepositStrategy());

            context.ExecuteTransaction(1000m, "UA555");
            publisher.PublishTransaction("DEPOSIT", 1000m, "UA555");

            context.SetStrategy(new WithdrawStrategy());
            context.ExecuteTransaction(200m, "UA555");
            publisher.PublishTransaction("WITHDRAW", 200m, "UA555");

            context.SetStrategy(new TransferStrategy("UA666"));
            context.ExecuteTransaction(300m, "UA555");
            publisher.PublishTransaction("TRANSFER", 300m, "UA555");

            decimal finalBalance = balanceUpdater.GetBalance("UA555");
            Assert.Equal(1500m, finalBalance);
        }
    }
}