using System;
using System.Linq;
using FitnessTracker.Application.Services;
using FitnessTracker.Application.Strategies;
using FitnessTracker.Domain.Entities;
using FitnessTracker.Infrastructure.Persistence;

namespace FitnessTracker.ConsoleApp
{
    class Program
    {
        private static WorkoutService _workoutService;
        private static User _currentUser;
        private static JsonWorkoutRepository _repository;
        private static CalorieCalculator _calorieCalculator;

        static void Main(string[] args)
        {
            System.Console.Write("Enter your name: ");
            string name = System.Console.ReadLine();
            System.Console.Write("Enter your weight (kg): ");
            double weight = double.Parse(System.Console.ReadLine());
            System.Console.Write("Enter your age: ");
            int age = int.Parse(System.Console.ReadLine());
            System.Console.Write("Enter gender (1-Male, 2-Female, 3-Other): ");
            Gender gender = (Gender)(int.Parse(System.Console.ReadLine()) - 1);
            
            _currentUser = new User(name, weight, age, gender);
            System.Console.WriteLine($"\nWelcome, {_currentUser.Name}!\n");

            _repository = new JsonWorkoutRepository();
            var standardStrategy = new StandardCalorieStrategy();
            _calorieCalculator = new CalorieCalculator(standardStrategy);
            _workoutService = new WorkoutService(_repository, _calorieCalculator, _currentUser);

            bool exit = false;
            while (!exit)
            {
                System.Console.WriteLine("\n=== FITNESS TRACKER ===");
                System.Console.WriteLine($"=== User: {_currentUser.Name} ===");
                System.Console.WriteLine("1. Add Workout");
                System.Console.WriteLine("2. View History");
                System.Console.WriteLine("3. Statistics");
                System.Console.WriteLine("4. Delete Workout");
                System.Console.WriteLine("5. Complete Workout");
                System.Console.WriteLine("6. Cancel Workout");
                System.Console.WriteLine("7. Filter by Type");
                System.Console.WriteLine("8. Analytics");
                System.Console.WriteLine("9. Change Strategy");
                System.Console.WriteLine("0. Exit");
                System.Console.Write("Choose: ");
                
                string choice = System.Console.ReadLine();
                
                switch (choice)
                {
                    case "1": AddWorkout(); break;
                    case "2": ViewHistory(); break;
                    case "3": ViewStatistics(); break;
                    case "4": DeleteWorkout(); break;
                    case "5": CompleteWorkout(); break;
                    case "6": CancelWorkout(); break;
                    case "7": FilterByType(); break;
                    case "8": ShowAnalytics(); break;
                    case "9": ChangeStrategy(); break;
                    case "0": exit = true; break;
                    default: System.Console.WriteLine("Invalid option"); break;
                }
            }
        }

        static void AddWorkout()
        {
            System.Console.WriteLine("\n--- Add Workout ---");
            var types = Enum.GetValues(typeof(WorkoutType));
            for (int i = 0; i < types.Length; i++)
                System.Console.WriteLine($"  {i + 1}. {types.GetValue(i)}");
            
            System.Console.Write("Select type: ");
            var type = (WorkoutType)(int.Parse(System.Console.ReadLine()) - 1);
            System.Console.Write("Date (yyyy-mm-dd): ");
            var date = DateTime.Parse(System.Console.ReadLine());
            System.Console.Write("Duration (1-240 min): ");
            int duration = int.Parse(System.Console.ReadLine());
            System.Console.Write("Intensity (1-Low,2-Medium,3-High): ");
            var intensity = (IntensityLevel)(int.Parse(System.Console.ReadLine()));
            
            try
            {
                var workout = _workoutService.AddWorkout(type, date, duration, intensity, "");
                System.Console.WriteLine($"Workout added! Calories: {(int)workout.CaloriesBurned}");
            }
            catch (Exception ex) { System.Console.WriteLine($"Error: {ex.Message}"); }
        }

        static void ViewHistory()
        {
            System.Console.WriteLine("\n--- Workout History ---");
            var workouts = _workoutService.GetWorkoutHistory();
            if (!workouts.Any()) { System.Console.WriteLine("No workouts found."); return; }
            foreach (var w in workouts)
                System.Console.WriteLine($"{w.Date:yyyy-MM-dd} | {w.Type} | {w.DurationMinutes} min | {(int)w.CaloriesBurned} cal | {w.Status}");
        }

        static void ViewStatistics()
        {
            System.Console.Write("From date (yyyy-mm-dd): ");
            var from = DateTime.Parse(System.Console.ReadLine());
            System.Console.Write("To date (yyyy-mm-dd): ");
            var to = DateTime.Parse(System.Console.ReadLine());
            System.Console.WriteLine($"Total calories: {(int)_workoutService.GetTotalCalories(from, to)}");
        }

        static void DeleteWorkout()
        {
            ViewHistory();
            System.Console.Write("Enter ID to delete: ");
            if (Guid.TryParse(System.Console.ReadLine(), out Guid id))
            {
                try { _workoutService.DeleteWorkout(id); System.Console.WriteLine("Deleted!"); }
                catch (Exception ex) { System.Console.WriteLine($"Error: {ex.Message}"); }
            }
        }

        static void CompleteWorkout()
        {
            ViewHistory();
            System.Console.Write("Enter ID to complete: ");
            if (Guid.TryParse(System.Console.ReadLine(), out Guid id))
            {
                try { _workoutService.CompleteWorkout(id); System.Console.WriteLine("Completed!"); }
                catch (Exception ex) { System.Console.WriteLine($"Error: {ex.Message}"); }
            }
        }

        static void CancelWorkout()
        {
            ViewHistory();
            System.Console.Write("Enter ID to cancel: ");
            if (Guid.TryParse(System.Console.ReadLine(), out Guid id))
            {
                try { _workoutService.CancelWorkout(id); System.Console.WriteLine("Cancelled!"); }
                catch (Exception ex) { System.Console.WriteLine($"Error: {ex.Message}"); }
            }
        }

        static void FilterByType()
        {
            var types = Enum.GetValues(typeof(WorkoutType));
            for (int i = 0; i < types.Length; i++)
                System.Console.WriteLine($"  {i + 1}. {types.GetValue(i)}");
            System.Console.Write("Select type: ");
            var type = (WorkoutType)(int.Parse(System.Console.ReadLine()) - 1);
            var workouts = _workoutService.GetWorkoutsByType(type);
            foreach (var w in workouts)
                System.Console.WriteLine($"{w.Date:yyyy-MM-dd} | {w.DurationMinutes} min | {(int)w.CaloriesBurned} cal");
        }

        static void ShowAnalytics()
        {
            var stats = _workoutService.GetWorkoutStatisticsByType();
            foreach (var s in stats)
                System.Console.WriteLine($"{s.Key}: {s.Value} workouts");
            var longest = _workoutService.GetLongestWorkout();
            if (longest != null)
                System.Console.WriteLine($"Longest: {longest.Type} - {longest.DurationMinutes} min");
        }

        static void ChangeStrategy()
        {
            System.Console.WriteLine($"Current: {_calorieCalculator.GetCurrentStrategyName()}");
            System.Console.WriteLine("1. Standard | 2. Advanced");
            var choice = System.Console.ReadLine();
            if (choice == "1") _calorieCalculator.SetStrategy(new StandardCalorieStrategy());
            else if (choice == "2") _calorieCalculator.SetStrategy(new AdvancedCalorieStrategy());
            else return;
            _workoutService = new WorkoutService(_repository, _calorieCalculator, _currentUser);
            System.Console.WriteLine("Strategy changed!");
        }
    }
}