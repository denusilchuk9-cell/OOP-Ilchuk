using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Domain.Interfaces
{
    public interface ICalorieStrategy
    {
        double Calculate(WorkoutType type, double weight, int durationMinutes, IntensityLevel intensity);
        string GetStrategyName();
    }
}