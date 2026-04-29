using System;
using FitnessTracker.Domain.Entities;
using FitnessTracker.Domain.Interfaces;

namespace FitnessTracker.Application.Strategies
{
    public class AdvancedCalorieStrategy : ICalorieStrategy
    {
        public double Calculate(WorkoutType type, double weight, int durationMinutes, IntensityLevel intensity)
        {
            double baseCalories = type switch
            {
                WorkoutType.Running => weight * 1.036,
                WorkoutType.Cycling => weight * 0.85,
                WorkoutType.Swimming => weight * 0.98,
                WorkoutType.Yoga => weight * 0.5,
                WorkoutType.StrengthTraining => weight * 0.78,
                WorkoutType.HIIT => weight * 1.2,
                _ => weight * 0.6
            };
            
            double intensityMultiplier = (int)intensity switch { 1 => 1.0, 2 => 1.3, 3 => 1.7, _ => 1.0 };
            return baseCalories * (durationMinutes / 60.0) * intensityMultiplier;
        }

        public string GetStrategyName() => "Advanced personalized calculation";
    }
}