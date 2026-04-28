using System;
using IndependentWork23.Models;

namespace IndependentWork23.Facade
{
    public class TaskNotifier
    {
        public void NotifyTaskCreated(TaskData task)
        {
            Console.WriteLine($"[NOTIFIER] Sending email: New task '{task.Title}' created");
            Console.WriteLine($"[NOTIFIER] Email sent to: {task.AssignedTo}@company.com");
        }

        public void NotifyTaskCompleted(TaskData task)
        {
            Console.WriteLine($"[NOTIFIER] Sending notification: Task '{task.Title}' completed");
            Console.WriteLine($"[NOTIFIER] Notification sent to project manager");
        }
    }
}