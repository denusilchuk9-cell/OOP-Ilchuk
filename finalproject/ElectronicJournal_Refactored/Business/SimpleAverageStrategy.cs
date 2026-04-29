using System.Collections.Generic;
using System.Linq;
using ElectronicJournal.Models;

namespace ElectronicJournal.Business
{
    public class SimpleAverageStrategy : IAverageStrategy
    {
        public double Calculate(List<Grade> grades)
        {
            if (grades == null || grades.Count == 0) return 0;
            return grades.Average(g => g.Value);
        }
    }
}