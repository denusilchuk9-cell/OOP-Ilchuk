using FitnessTracker.Domain.Entities;
using FitnessTracker.Domain.Interfaces;

namespace FitnessTracker.Application.Services
{
    public class CalorieCalculator : ICalorieCalculator
    {
        private ICalorieStrategy _strategy;

        public CalorieCalculator(ICalorieStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(ICalorieStrategy strategy)
        {
            _strategy = strategy;
        }

        public double CalculateCalories(WorkoutType type, double weight, int durationMinutes, IntensityLevel intensity)
        {
            return _strategy.Calculate(type, weight, durationMinutes, intensity);
        }

        public string GetCurrentStrategyName() => _strategy.GetStrategyName();
    }
}