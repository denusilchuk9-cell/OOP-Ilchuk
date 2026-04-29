using System;
using IndependentWork23.Models;
using IndependentWork23.Adapter;
using IndependentWork23.Facade;
using IndependentWork23.Proxy;

namespace IndependentWork23
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Independent Work #23: Adapter + Facade + Proxy ===\n");
            Console.WriteLine("Scenario: Task Management System\n");

            Console.WriteLine(new string('=', 60));
            Console.WriteLine("PART 1: ADAPTER PATTERN DEMONSTRATION");
            Console.WriteLine(new string('=', 60));

            LegacyTaskRunner legacyRunner = new LegacyTaskRunner();
            ITaskExecutor adapter = new LegacyTaskAdapter(legacyRunner);

            TaskData newTask = new TaskData(42, "Implement Login Feature", "Add OAuth2 authentication", "alice");
            Console.WriteLine($"\nModern Task created: {newTask.Title}");

            string result = adapter.ExecuteTask(newTask);
            Console.WriteLine($"\n{result}");
            Console.WriteLine($"\nTask completed status: {newTask.IsCompleted}");

            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("PART 2: FACADE PATTERN DEMONSTRATION");
            Console.WriteLine(new string('=', 60));

            TaskManagerFacade taskFacade = new TaskManagerFacade();

            TaskData scheduledTask = taskFacade.ScheduleTask(
                "Deploy to Production",
                "Deploy the latest build to production servers",
                "devops");

            if (scheduledTask != null)
            {
                Console.WriteLine($"\nScheduled Task Details:\n{scheduledTask}");
                taskFacade.CompleteTask(scheduledTask);
            }

            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("PART 3: PROXY PATTERN DEMONSTRATION");
            Console.WriteLine(new string('=', 60));

            Console.WriteLine("\n--- Scenario A: Admin user (full access) ---");
            ITaskService adminProxy = new PermissionTaskServiceProxy("admin");

            TaskData task1 = adminProxy.GetTask(1);
            Console.WriteLine($"Result: {task1}");

            TaskData task2 = adminProxy.GetTask(2);
            Console.WriteLine($"Result: {task2}");

            TaskData task1Cached = adminProxy.GetTask(1);
            Console.WriteLine($"Result (cached): {task1Cached}");

            string completeResult = adminProxy.CompleteTask(1);
            Console.WriteLine($"Complete result: {completeResult}");

            Console.WriteLine("\n--- Scenario B: Viewer user (read-only) ---");
            ITaskService viewerProxy = new PermissionTaskServiceProxy("viewer");

            TaskData viewerTask = viewerProxy.GetTask(2);
            Console.WriteLine($"Result: {viewerTask}");

            string viewerComplete = viewerProxy.CompleteTask(2);
            Console.WriteLine($"Complete result: {viewerComplete}");

            Console.WriteLine("\n--- Scenario C: Rate limiting demonstration ---");
            ITaskService rateLimitProxy = new PermissionTaskServiceProxy("developer");

            for (int i = 1; i <= 7; i++)
            {
                Console.WriteLine($"\nRequest #{i}:");
                TaskData task = rateLimitProxy.GetTask(1);
                if (task == null)
                {
                    Console.WriteLine("Request failed due to access or rate limit");
                }
            }

            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("DEMONSTRATION SUMMARY");
            Console.WriteLine(new string('=', 60));

            Console.WriteLine("\nADAPTER Pattern:");
            Console.WriteLine("  - Problem: Legacy system uses different interface (RunTask with primitives)");
            Console.WriteLine("  - Solution: Adapter converts modern Task object to legacy format");
            Console.WriteLine("  - Benefit: Can use existing legacy code without modification");

            Console.WriteLine("\nFACADE Pattern:");
            Console.WriteLine("  - Problem: Complex task management requires multiple steps");
            Console.WriteLine("  - Solution: Facade provides simple ScheduleTask() and CompleteTask() methods");
            Console.WriteLine("  - Benefit: Client code doesn't need to know about Creator, Assigner, Notifier");

            Console.WriteLine("\nPROXY Pattern:");
            Console.WriteLine("  - Problem: Need to control access to expensive operations");
            Console.WriteLine("  - Solution: Proxy adds permission checks, caching, and rate limiting");
            Console.WriteLine("  - Benefit: Security + Performance optimization without changing RealService");

            Console.WriteLine("\nARCHITECTURAL COMPROMISES:");
            Console.WriteLine("  - Adapter adds extra layer (minor performance impact)");
            Console.WriteLine("  - Facade may hide useful low-level operations");
            Console.WriteLine("  - Proxy increases complexity and memory usage (cache)");
            Console.WriteLine("  - Rate limiting may block legitimate users");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}