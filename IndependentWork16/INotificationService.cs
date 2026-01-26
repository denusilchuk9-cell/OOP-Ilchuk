using System;

namespace IndependentWork16
{
    public interface INotificationService
    {
        void SendNotification(string message);
    }

    public class EmailNotificationService : INotificationService
    {
        public void SendNotification(string message)
        {
            Console.WriteLine($"Сповіщення: {message}");
        }
    }
}