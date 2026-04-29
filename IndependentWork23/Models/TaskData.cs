namespace IndependentWork23.Models
{
    public class TaskData
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AssignedTo { get; set; }
        public bool IsCompleted { get; set; }

        public TaskData()
        {
            Title = string.Empty;
            Description = string.Empty;
            AssignedTo = string.Empty;
        }

        public TaskData(int id, string title, string description, string assignedTo)
        {
            Id = id;
            Title = title;
            Description = description;
            AssignedTo = assignedTo;
            IsCompleted = false;
        }

        public override string ToString()
        {
            return $"[Task #{Id}] {Title} - {Description} (Assigned to: {AssignedTo}, Completed: {IsCompleted})";
        }
    }
}