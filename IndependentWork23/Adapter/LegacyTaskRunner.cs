using System;
using IndependentWork23.Models;

namespace IndependentWork23.Adapter
{
    public class LegacyTaskRunner
    {
        public string RunTask(int taskId, string taskName, string taskData, string assignee)
        {
            Console.WriteLine($"[LEGACY] Running task with old system...");
            Console.WriteLine($"[LEGACY] TaskId: {taskId}, Name: {taskName}, Data: {taskData}, Assignee: {assignee}");

            if (taskId <= 0)
            {
                return "ERROR: Invalid task ID";
            }

            if (string.IsNullOrEmpty(taskName))
            {
                return "ERROR: Task name cannot be empty";
            }

            return $"SUCCESS: Task '{taskName}' (ID: {taskId}) executed by legacy system. Assigned to: {assignee}";
        }
    }
}