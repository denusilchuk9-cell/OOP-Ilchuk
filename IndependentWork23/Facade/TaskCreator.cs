using System;
using IndependentWork23.Models;

namespace IndependentWork23.Facade
{
    public class TaskCreator
    {
        private static int _nextId = 100;

        public TaskData CreateTask(string title, string description, string assignedTo)
        {
            Console.WriteLine($"[CREATOR] Creating new task: {title}");
            var task = new TaskData(_nextId++, title, description, assignedTo);
            Console.WriteLine($"[CREATOR] Task created with ID: {task.Id}");
            return task;
        }
    }
}