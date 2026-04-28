using System;
using System.Collections.Generic;
using ElectronicJournal.Models;

namespace ElectronicJournal.Interfaces
{
    public interface IAttendanceRepository : IRepository<Attendance>
    {
        List<Attendance> GetByStudent(int studentId);
        List<Attendance> GetByDate(DateTime date);
    }
}