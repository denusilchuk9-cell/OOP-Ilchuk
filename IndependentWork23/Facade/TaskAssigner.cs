using System;
using IndependentWork23.Models;

namespace IndependentWork23.Facade
{
    public class TaskAssigner
    {
        public void AssignTask(TaskData task, string assignee)
        {
            Console.WriteLine($"[ASSIGNER] Assigning task '{task.Title}' to {assignee}");
            task.AssignedTo = assignee;
            Console.WriteLine($"[ASSIGNER] Task assigned successfully");
        }

        public bool CanAssign(string assignee)
        {
            bool isValid = !string.IsNullOrEmpty(assignee) && assignee.Length >= 3;
            Console.WriteLine($"[ASSIGNER] Checking if '{assignee}' can be assigned: {isValid}");
            return isValid;
        }
    }
}