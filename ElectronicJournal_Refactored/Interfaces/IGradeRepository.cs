using System.Collections.Generic;
using ElectronicJournal.Models;

namespace ElectronicJournal.Interfaces
{
    public interface IGradeRepository : IRepository<Grade>
    {
        List<Grade> GetByStudent(int studentId);
        List<Grade> GetBySubject(int subjectId);
        float GetAverage(int studentId, int subjectId);
    }
}