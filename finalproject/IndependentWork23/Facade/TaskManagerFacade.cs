using System;
using IndependentWork23.Models;

namespace IndependentWork23.Facade
{
    public class TaskManagerFacade
    {
        private TaskCreator _creator;
        private TaskAssigner _assigner;
        private TaskNotifier _notifier;

        public TaskManagerFacade()
        {
            _creator = new TaskCreator();
            _assigner = new TaskAssigner();
            _notifier = new TaskNotifier();
        }

        public TaskData ScheduleTask(string title, string description, string assignee)
        {
            Console.WriteLine("\n[FACADE] Starting task scheduling process...");

            if (!_assigner.CanAssign(assignee))
            {
                Console.WriteLine("[FACADE] ERROR: Invalid assignee name");
                return null;
            }

            TaskData task = _creator.CreateTask(title, description, assignee);
            _assigner.AssignTask(task, assignee);
            _notifier.NotifyTaskCreated(task);

            Console.WriteLine("[FACADE] Task scheduling completed successfully");
            return task;
        }

        public void CompleteTask(TaskData task)
        {
            Console.WriteLine("\n[FACADE] Starting task completion process...");

            task.IsCompleted = true;
            _notifier.NotifyTaskCompleted(task);

            Console.WriteLine("[FACADE] Task completion process finished");
        }
    }
}