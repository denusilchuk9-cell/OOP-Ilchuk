using System;

namespace FitnessTrackerApp.Domain.Entities
{
	public class Workout
	{
		public Guid Id { get; private set; }
		public Guid UserId { get; private set; }
		public WorkoutType Type { get; private set; }
		public DateTime Date { get; private set; }
		public int DurationMinutes { get; private set; }
		public IntensityLevel Intensity { get; private set; }
		public double CaloriesBurned { get; private set; }
		public string Notes { get; private set; }

		public Workout(Guid userId, WorkoutType type, DateTime date, int durationMinutes, IntensityLevel intensity, double caloriesBurned, string notes = "")
		{
			Id = Guid.NewGuid();
			UserId = userId;
			Type = type;
			Date = date;
			DurationMinutes = durationMinutes;
			Intensity = intensity;
			CaloriesBurned = caloriesBurned;
			Notes = notes;
		}
	}

	public enum WorkoutType
	{
		Running,
		Walking,
		Cycling,
		Swimming,
		Yoga,
		StrengthTraining,
		HIIT
	}

	public enum IntensityLevel
	{
		Low = 1,
		Medium = 2,
		High = 3
	}
}