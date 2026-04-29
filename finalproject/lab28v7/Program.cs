using System;
using System.Collections.Generic;
using lab28v7.Models;
using lab28v7.Repositories;

namespace lab28v7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Task Repository with JSON Serialization ===\n");

            TaskRepository repository = new TaskRepository();

            Project webProject = new Project(0, "Website Redesign", "Redesign company website with new UI");
            webProject.CreatedDate = new DateTime(2024, 1, 15);

            WorkTask task1 = new WorkTask(0, "Design mockups", "Create Figma designs for main pages", 1);
            WorkTask task2 = new WorkTask(0, "Develop frontend", "Implement React components", 2);
            WorkTask task3 = new WorkTask(0, "Testing", "Cross-browser testing", 3);

            repository.Add(webProject);
            repository.AddTaskToProject(webProject.Id, task1);
            repository.AddTaskToProject(webProject.Id, task2);
            repository.AddTaskToProject(webProject.Id, task3);

            Project mobileProject = new Project(0, "Mobile App", "iOS and Android app development");
            mobileProject.CreatedDate = new DateTime(2024, 2, 1);

            WorkTask task4 = new WorkTask(0, "API development", "Create REST API backend", 1);
            WorkTask task5 = new WorkTask(0, "UI/UX design", "Mobile-first design", 2);

            repository.Add(mobileProject);
            repository.AddTaskToProject(mobileProject.Id, task4);
            repository.AddTaskToProject(mobileProject.Id, task5);

            Console.WriteLine("=== Created Objects ===");
            DisplayAllProjects(repository.GetAll());

            string filename = "projects.json";
            repository.SaveToFile(filename);
            Console.WriteLine($"\nData saved to {filename}");

            TaskRepository newRepository = new TaskRepository();
            newRepository.LoadFromFile(filename);
            Console.WriteLine($"\nData loaded from {filename}");

            Console.WriteLine("\n=== Loaded Objects ===");
            DisplayAllProjects(newRepository.GetAll());

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void DisplayAllProjects(List<Project> projects)
        {
            foreach (var project in projects)
            {
                Console.WriteLine($"\nProject ID: {project.Id}");
                Console.WriteLine($"Project Name: {project.Name}");
                Console.WriteLine($"Description: {project.Description}");
                Console.WriteLine($"Created: {project.CreatedDate:yyyy-MM-dd}");
                Console.WriteLine($"Tasks ({project.Tasks.Count}):");

                foreach (var task in project.Tasks)
                {
                    string status = task.IsCompleted ? "[DONE]" : "[PENDING]";
                    Console.WriteLine($"  - Task {task.Id}: {task.Title} (Priority: {task.Priority}) {status}");
                }
            }
        }
    }
}