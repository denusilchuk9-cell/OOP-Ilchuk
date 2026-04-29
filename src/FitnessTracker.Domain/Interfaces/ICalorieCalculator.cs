using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Domain.Interfaces
{
    public interface ICalorieCalculator
    {
        double CalculateCalories(WorkoutType type, double weight, int durationMinutes, IntensityLevel intensity);
    }
}