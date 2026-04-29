using System.Collections.Generic;
using FitnessTracker.Domain.Entities;
using FitnessTracker.Domain.Interfaces;

namespace FitnessTracker.Application.Strategies
{
    public class StandardCalorieStrategy : ICalorieStrategy
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

        public double Calculate(WorkoutType type, double weight, int durationMinutes, IntensityLevel intensity)
        {
            double met = _metValues.GetValueOrDefault(type, 5.0);
            met *= (int)intensity switch { 1 => 0.8, 3 => 1.3, _ => 1.0 };
            return met * weight * (durationMinutes / 60.0);
        }

        public string GetStrategyName() => "Standard MET-based calculation";
    }
}