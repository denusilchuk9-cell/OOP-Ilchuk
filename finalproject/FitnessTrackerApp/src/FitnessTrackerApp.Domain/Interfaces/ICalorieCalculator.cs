using FitnessTrackerApp.Domain.Entities;

namespace FitnessTrackerApp.Domain.Interfaces
{
    public interface ICalorieCalculator
    {
        double CalculateCalories(WorkoutType type, double weight, int durationMinutes, IntensityLevel intensity);
    }
}