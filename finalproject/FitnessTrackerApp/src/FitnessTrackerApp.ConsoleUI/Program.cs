using System;
using System.Linq;
using FitnessTrackerApp.Application.Services;
using FitnessTrackerApp.Domain.Entities;
using FitnessTrackerApp.Infrastructure.Persistence;

namespace FitnessTrackerApp.ConsoleUI
{
    class Program
    {
        private static WorkoutService _workoutService;
        private static User _currentUser;

        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter weight (kg): ");
            double weight = double.Parse(Console.ReadLine());
            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Gender (1-Male,2-Female,3-Other): ");
            Gender gender = (Gender)(int.Parse(Console.ReadLine()) - 1);

            _currentUser = new User(name, weight, age, gender);
            Console.WriteLine($"\nWelcome {_currentUser.Name}!\n");

            var repository = new JsonWorkoutRepository();
            var calculator = new CalorieCalculator();
            _workoutService = new WorkoutService(repository, calculator, _currentUser);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n=== FITNESS TRACKER ===");
                Console.WriteLine("1. Add Workout");
                Console.WriteLine("2. View History");
                Console.WriteLine("3. View Statistics");
                Console.WriteLine("4. Delete Workout");
                Console.WriteLine("0. Exit");
                Console.Write("Choose: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddWorkout();
                        break;
                    case "2":
                        ViewHistory();
                        break;
                    case "3":
                        ViewStatistics();
                        break;
                    case "4":
                        DeleteWorkout();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

        static void AddWorkout()
        {
            Console.WriteLine("\nWorkout types:");
            var types = Enum.GetValues(typeof(WorkoutType));
            for (int i = 0; i < types.Length; i++)
                Console.WriteLine($"  {i + 1}. {types.GetValue(i)}");

            Console.Write("Select type: ");
            var type = (WorkoutType)(int.Parse(Console.ReadLine()) - 1);
            Console.Write("Date (yyyy-mm-dd): ");
            var date = DateTime.Parse(Console.ReadLine());
            Console.Write("Duration (1-240 min): ");
            int duration = int.Parse(Console.ReadLine());
            Console.Write("Intensity (1-Low,2-Medium,3-High): ");
            var intensity = (IntensityLevel)(int.Parse(Console.ReadLine()));

            try
            {
                var workout = _workoutService.AddWorkout(type, date, duration, intensity, "");
                Console.WriteLine($"Workout added! Calories: {(int)workout.CaloriesBurned}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ViewHistory()
        {
            Console.WriteLine("\n--- Workout History ---");
            var workouts = _workoutService.GetWorkoutHistory();
            if (!workouts.Any())
            {
                Console.WriteLine("No workouts found.");
                return;
            }
            foreach (var w in workouts)
                Console.WriteLine($"{w.Date:yyyy-MM-dd} | {w.Type} | {w.DurationMinutes} min | {(int)w.CaloriesBurned} cal");
        }

        static void ViewStatistics()
        {
            Console.Write("From date (yyyy-mm-dd): ");
            var from = DateTime.Parse(Console.ReadLine());
            Console.Write("To date (yyyy-mm-dd): ");
            var to = DateTime.Parse(Console.ReadLine());

            var workouts = _workoutService.GetWorkoutHistory(from, to);
            Console.WriteLine($"\nTotal workouts: {workouts.Count()}");
            Console.WriteLine($"Total calories: {(int)_workoutService.GetTotalCalories(from, to)}");
        }

        static void DeleteWorkout()
        {
            ViewHistory();
            Console.Write("Enter workout ID to delete: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid id))
            {
                try
                {
                    _workoutService.DeleteWorkout(id);
                    Console.WriteLine("Deleted!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}