using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using lab28v7.Models;

namespace lab28v7.Repositories
{
    public class TaskRepository
    {
        private List<Project> _projects;
        private int _nextProjectId;
        private int _nextTaskId;

        public TaskRepository()
        {
            _projects = new List<Project>();
            _nextProjectId = 1;
            _nextTaskId = 1;
        }

        public void Add(Project project)
        {
            if (project.Id == 0)
            {
                project.Id = _nextProjectId++;
            }
            _projects.Add(project);
        }

        public void AddTaskToProject(int projectId, WorkTask task)
        {
            var project = _projects.FirstOrDefault(p => p.Id == projectId);
            if (project != null)
            {
                if (task.Id == 0)
                {
                    task.Id = _nextTaskId++;
                }
                project.Tasks.Add(task);
            }
        }

        public List<Project> GetAll()
        {
            return _projects;
        }

        public Project GetById(int id)
        {
            return _projects.FirstOrDefault(p => p.Id == id);
        }

        public void SaveToFile(string filename)
        {
            string jsonString = JsonConvert.SerializeObject(_projects, Formatting.Indented);
            File.WriteAllText(filename, jsonString);
        }

        public void LoadFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                return;
            }

            string jsonString = File.ReadAllText(filename);
            var loadedProjects = JsonConvert.DeserializeObject<List<Project>>(jsonString);

            if (loadedProjects != null)
            {
                _projects = loadedProjects;

                if (_projects.Any())
                {
                    _nextProjectId = _projects.Max(p => p.Id) + 1;

                    var allTasks = _projects.SelectMany(p => p.Tasks);
                    if (allTasks.Any())
                    {
                        _nextTaskId = allTasks.Max(t => t.Id) + 1;
                    }
                }
            }
        }
    }
}