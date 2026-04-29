using System;
using System.Collections.Generic;
using System.Linq;
using ElectronicJournal.Interfaces;
using ElectronicJournal.Models;

namespace ElectronicJournal.Data
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private static List<Attendance> _attendances = new List<Attendance>();
        private static int _nextId = 1;

        public List<Attendance> GetAll()
        {
            return _attendances.ToList();
        }

        public Attendance GetById(int id)
        {
            return _attendances.FirstOrDefault(a => a.Id == id);
        }

        public void Add(Attendance attendance)
        {
            if (attendance == null)
                throw new ArgumentNullException(nameof(attendance));

            attendance.Id = _nextId++;
            _attendances.Add(attendance);
        }

        public void Update(Attendance attendance)
        {
            var existing = GetById(attendance.Id);
            if (existing != null)
            {
                existing.StudentId = attendance.StudentId;
                existing.SubjectId = attendance.SubjectId;
                existing.Date = attendance.Date;
                existing.IsPresent = attendance.IsPresent;
                existing.AbsenceReason = attendance.AbsenceReason;
            }
        }

        public void Delete(int id)
        {
            var attendance = GetById(id);
            if (attendance != null)
                _attendances.Remove(attendance);
        }

        public List<Attendance> GetByStudent(int studentId)
        {
            return _attendances.Where(a => a.StudentId == studentId).ToList();
        }

        public List<Attendance> GetByDate(DateTime date)
        {
            return _attendances.Where(a => a.Date.Date == date.Date).ToList();
        }
    }
}