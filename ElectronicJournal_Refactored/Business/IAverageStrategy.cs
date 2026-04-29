using System.Collections.Generic;
using ElectronicJournal.Models;

namespace ElectronicJournal.Business
{
    public interface IAverageStrategy
    {
        double Calculate(List<Grade> grades);
    }
}