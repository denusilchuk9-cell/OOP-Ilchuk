using System;

namespace lab28v7.Models
{
    public class WorkTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public int Priority { get; set; }

        public WorkTask()
        {
            Title = string.Empty;
            Description = string.Empty;
        }

        public WorkTask(int id, string title, string description, int priority)
        {
            Id = id;
            Title = title;
            Description = description;
            IsCompleted = false;
            Priority = priority;
        }
    }
}