using System.Collections.Generic;
using ElectronicJournal.Models;

namespace ElectronicJournal.Interfaces
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        List<Subject> GetByTeacher(string teacher);
    }
}