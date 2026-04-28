using System;
using System.Collections.Generic;
using System.Linq;
using FitnessTrackerApp.Domain.Entities;
using FitnessTrackerApp.Domain.Interfaces;

namespace FitnessTrackerApp.Application.Services
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
			if (date > DateTime.Now)
				throw new InvalidOperationException("Cannot add workout in the future");
			if (durationMinutes < 1 || durationMinutes > 240)
				throw new ArgumentException("Duration must be between 1 and 240 minutes");

			double calories = _calculator.CalculateCalories(type, _currentUser.Weight, durationMinutes, intensity);
			var workout = new Workout(_currentUser.Id, type, date, durationMinutes, intensity, calories, notes);
			_repository.Add(workout);
			_repository.Save();
			return workout;
		}

		public IEnumerable<Workout> GetWorkoutHistory(DateTime? from = null, DateTime? to = null)
		{
			var workouts = _repository.GetByUserId(_currentUser.Id);
			if (from.HasValue) workouts = workouts.Where(w => w.Date >= from.Value);
			if (to.HasValue) workouts = workouts.Where(w => w.Date <= to.Value);
			return workouts.OrderByDescending(w => w.Date);
		}

		public void DeleteWorkout(Guid workoutId)
		{
			var workout = _repository.GetById(workoutId);
			if (workout == null) throw new Exception("Workout not found");
			if (workout.UserId != _currentUser.Id) throw new Exception("Cannot delete another user's workout");
			_repository.Delete(workoutId);
			_repository.Save();
		}

		public double GetTotalCalories(DateTime start, DateTime end)
		{
			return GetWorkoutHistory(start, end).Sum(w => w.CaloriesBurned);
		}
	}
}