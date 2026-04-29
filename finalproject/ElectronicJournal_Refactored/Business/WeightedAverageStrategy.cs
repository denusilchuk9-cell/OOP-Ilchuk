using System.Collections.Generic;
using ElectronicJournal.Models;

namespace ElectronicJournal.Business
{
    public class WeightedAverageStrategy : IAverageStrategy
    {
        public double Calculate(List<Grade> grades)
        {
            if (grades == null || grades.Count == 0) return 0;
            double total = 0;
            double weightSum = 0;
            for (int i = 0; i < grades.Count; i++)
            {
                double weight = i + 1;
                total += grades[i].Value * weight;
                weightSum += weight;
            }
            return total / weightSum;
        }
    }
}