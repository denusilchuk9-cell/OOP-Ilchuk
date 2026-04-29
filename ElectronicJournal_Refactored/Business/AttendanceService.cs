using System;
using System.Collections.Generic;
using ElectronicJournal.Interfaces;
using ElectronicJournal.Models;

namespace ElectronicJournal.Business
{
    public class AttendanceService
    {
        private IAttendanceRepository _attendanceRepository;
        private IStudentRepository _studentRepository;
        private ISubjectRepository _subjectRepository;

        public AttendanceService(IAttendanceRepository attendanceRepo, IStudentRepository studentRepo, ISubjectRepository subjectRepo)
        {
            _attendanceRepository = attendanceRepo;
            _studentRepository = studentRepo;
            _subjectRepository = subjectRepo;
        }

        public List<Attendance> GetAttendanceByStudent(int studentId)
        {
            return _attendanceRepository.GetByStudent(studentId);
        }

        public void AddAttendance(Attendance attendance)
        {
            if (attendance == null)
                throw new ArgumentNullException(nameof(attendance));
            _attendanceRepository.Add(attendance);
        }

        public void MarkAbsent(int studentId, int subjectId, DateTime date, string reason)
        {
            if (string.IsNullOrWhiteSpace(reason))
                throw new ArgumentException("Причина відсутності не може бути порожньою");

            var attendance = new Attendance(studentId, subjectId, date);
            attendance.MarkAbsent(reason);
            _attendanceRepository.Add(attendance);
        }

        public float GetAttendancePercentage(int studentId)
        {
            var attendances = _attendanceRepository.GetByStudent(studentId);
            if (attendances.Count == 0) return 0;
            int present = 0;
            foreach (var a in attendances)
                if (a.IsPresent) present++;
            return (float)present / attendances.Count * 100;
        }
    }
}