using System.Collections.Generic;
using ElectronicJournal.Models;

namespace ElectronicJournal.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        List<Student> FindByName(string name);
    }
}