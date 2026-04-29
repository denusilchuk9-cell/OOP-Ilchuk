using System;
using System.Collections.Generic;
using System.Linq;
using FitnessTracker.Domain.Entities;
using FitnessTracker.Domain.Interfaces;

namespace FitnessTracker.Application.Services
{
    public class WorkoutService
    {
        private readonly IWorkoutRepository _repository;
        private readonly ICalorieCalculator _calculator;
        private readonly User _currentUser;

        public WorkoutService(IWorkoutRepository repository, ICalorieCalculator calculator, User currentUser)
        {
            _repository = repository;
            _calculator = calculator;
            _currentUser = currentUser;
        }

        public Workout AddWorkout(WorkoutType type, DateTime date, int durationMinutes, IntensityLevel intensity, string notes = "")
        {
            if (date > DateTime.Now.AddDays(7))
                throw new InvalidOperationException("Cannot add workout more than 7 days in advance");

            if (durationMinutes < 1 || durationMinutes > 240)
                throw new ArgumentException("Duration must be between 1 and 240 minutes");

            double calories = _calculator.CalculateCalories(type, _currentUser.Weight, durationMinutes, intensity);
            
            var lastWorkout = _repository.GetByUserId(_currentUser.Id).OrderByDescending(w => w.Date).FirstOrDefault();
            if (lastWorkout != null && (date - lastWorkout.Date).TotalHours < 1)
                throw new InvalidOperationException("Cannot add workout too close to previous one (minimum 1 hour gap)");

            var workout = new Workout(_currentUser.Id, type, date, durationMinutes, intensity, calories, notes);
            _repository.Add(workout);
            _repository.SaveAsync().GetAwaiter().GetResult();
            
            return workout;
        }

        public IEnumerable<Workout> GetWorkoutHistory(DateTime? from = null, DateTime? to = null)
        {
            var workouts = _repository.GetByUserId(_currentUser.Id);
            if (from.HasValue)
                workouts = workouts.Where(w => w.Date >= from.Value);
            if (to.HasValue)
                workouts = workouts.Where(w => w.Date <= to.Value);
            return workouts.OrderByDescending(w => w.Date);
        }

        public void DeleteWorkout(Guid workoutId)
        {
            var workout = _repository.GetById(workoutId);
            if (workout == null)
                throw new KeyNotFoundException($"Workout with ID {workoutId} not found");
            if (workout.UserId != _currentUser.Id)
                throw new UnauthorizedAccessException("Cannot delete another user's workout");
            _repository.Delete(workoutId);
            _repository.SaveAsync().GetAwaiter().GetResult();
        }

        public double GetTotalCalories(DateTime start, DateTime end)
        {
            return GetWorkoutHistory(start, end).Sum(w => w.CaloriesBurned);
        }

        public void CompleteWorkout(Guid workoutId)
        {
            var workout = _repository.GetById(workoutId);
            if (workout == null)
                throw new KeyNotFoundException($"Workout with ID {workoutId} not found");
            if (workout.UserId != _currentUser.Id)
                throw new UnauthorizedAccessException("Cannot complete another user's workout");
            
            workout.Complete();
            _repository.Update(workout);
            _repository.SaveAsync().GetAwaiter().GetResult();
        }

        public void CancelWorkout(Guid workoutId)
        {
            var workout = _repository.GetById(workoutId);
            if (workout == null)
                throw new KeyNotFoundException($"Workout with ID {workoutId} not found");
            if (workout.UserId != _currentUser.Id)
                throw new UnauthorizedAccessException("Cannot cancel another user's workout");
            
            workout.Cancel();
            _repository.Update(workout);
            _repository.SaveAsync().GetAwaiter().GetResult();
        }

        public IEnumerable<Workout> GetWorkoutsByType(WorkoutType type)
        {
            return _repository.GetByUserId(_currentUser.Id)
                .Where(w => w.Type == type)
                .OrderByDescending(w => w.Date);
        }

        public Dictionary<WorkoutType, int> GetWorkoutStatisticsByType()
        {
            return _repository.GetByUserId(_currentUser.Id)
                .GroupBy(w => w.Type)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public Dictionary<IntensityLevel, double> GetAverageCaloriesByIntensity()
        {
            return _repository.GetByUserId(_currentUser.Id)
                .GroupBy(w => w.Intensity)
                .ToDictionary(g => g.Key, g => g.Average(w => w.CaloriesBurned));
        }

        public Workout GetLongestWorkout()
        {
            return _repository.GetByUserId(_currentUser.Id)
                .OrderByDescending(w => w.DurationMinutes)
                .FirstOrDefault();
        }

        public double GetAverageWorkoutDuration()
        {
            return _repository.GetByUserId(_currentUser.Id)
                .Average(w => w.DurationMinutes);
        }
    }
}