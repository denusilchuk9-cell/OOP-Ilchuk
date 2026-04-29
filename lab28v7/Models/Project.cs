using System;
using System.Collections.Generic;

namespace lab28v7.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<WorkTask> Tasks { get; set; }

        public Project()
        {
            Name = string.Empty;
            Description = string.Empty;
            Tasks = new List<WorkTask>();
        }

        public Project(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            CreatedDate = DateTime.Now;
            Tasks = new List<WorkTask>();
        }
    }
}