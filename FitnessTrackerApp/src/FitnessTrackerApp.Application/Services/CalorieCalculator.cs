using System.Collections.Generic;
using FitnessTrackerApp.Domain.Entities;
using FitnessTrackerApp.Domain.Interfaces;

namespace FitnessTrackerApp.Application.Services
{
    public class CalorieCalculator : ICalorieCalculator
    {
        private readonly Dictionary<WorkoutType, double> _metValues = new()
        {
            { WorkoutType.Running, 9.8 },
            { WorkoutType.Walking, 3.5 },
            { WorkoutType.Cycling, 7.5 },
            { WorkoutType.Swimming, 8.0 },
            { WorkoutType.Yoga, 3.0 },
            { WorkoutType.StrengthTraining, 5.0 },
            { WorkoutType.HIIT, 10.0 }
        };

        public double CalculateCalories(WorkoutType type, double weight, int durationMinutes, IntensityLevel intensity)
        {
            double met = _metValues.GetValueOrDefault(type, 5.0);
            met *= (int)intensity == 1 ? 0.8 : (int)intensity == 3 ? 1.3 : 1.0;
            return met * weight * (durationMinutes / 60.0);
        }
    }
}