using System;
using System.Collections.Generic;
using IndependentWork23.Models;

namespace IndependentWork23.Proxy
{
    public class RealTaskService : ITaskService
    {
        private Dictionary<int, TaskData> _tasks;

        public RealTaskService()
        {
            _tasks = new Dictionary<int, TaskData>();
            _tasks[1] = new TaskData(1, "Database Optimization", "Optimize SQL queries", "admin");
            _tasks[2] = new TaskData(2, "API Documentation", "Write Swagger documentation", "developer");
            _tasks[3] = new TaskData(3, "Security Audit", "Perform security review", "security");

            Console.WriteLine("[REAL SERVICE] Database connection established");
            Console.WriteLine("[REAL SERVICE] Loaded 3 tasks from database");
        }

        public TaskData GetTask(int id)
        {
            Console.WriteLine($"[REAL SERVICE] Executing SQL: SELECT * FROM Tasks WHERE Id = {id}");
            System.Threading.Thread.Sleep(500);

            if (_tasks.ContainsKey(id))
            {
                return _tasks[id];
            }
            return null;
        }

        public string CompleteTask(int id)
        {
            Console.WriteLine($"[REAL SERVICE] Executing SQL: UPDATE Tasks SET IsCompleted = true WHERE Id = {id}");
            System.Threading.Thread.Sleep(300);

            if (_tasks.ContainsKey(id))
            {
                _tasks[id].IsCompleted = true;
                return $"SUCCESS: Task {id} completed";
            }
            return $"ERROR: Task {id} not found";
        }
    }
}