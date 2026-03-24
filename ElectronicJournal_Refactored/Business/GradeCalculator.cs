using System.Collections.Generic;
using System.Linq;
using ElectronicJournal.Models;

namespace ElectronicJournal.Business
{
    public class GradeCalculator
    {
        private IAverageStrategy _strategy;

        public GradeCalculator() => _strategy = new SimpleAverageStrategy();

        public void SetStrategy(IAverageStrategy strategy) => _strategy = strategy;

        public string GetStrategyName()
        {
            if (_strategy is SimpleAverageStrategy) return "Проста (Simple)";
            if (_strategy is WeightedAverageStrategy) return "Зважена (Weighted)";
            return "Невідома";
        }

        public double CalculateAverage(List<Grade> grades) => _strategy.Calculate(grades);
        public double CalculateAverageByStudent(List<Grade> grades, int studentId)
            => _strategy.Calculate(grades.Where(g => g.StudentId == studentId).ToList());
        public double CalculateAverageBySubject(List<Grade> grades, int subjectId)
            => _strategy.Calculate(grades.Where(g => g.SubjectId == subjectId).ToList());
        public double CalculateAttendancePercentage(List<Attendance> attendances)
        {
            if (attendances == null || attendances.Count == 0) return 0;
            return (double)attendances.Count(a => a.IsPresent) / attendances.Count * 100;
        }
    }
}