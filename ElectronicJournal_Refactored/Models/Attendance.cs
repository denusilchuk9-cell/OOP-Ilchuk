using System;

namespace ElectronicJournal.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
        public string AbsenceReason { get; set; }

        public Attendance(int studentId, int subjectId, DateTime date)
        {
            if (studentId <= 0)
                throw new ArgumentException("Невірний ID студента");
            if (subjectId <= 0)
                throw new ArgumentException("Невірний ID предмета");

            StudentId = studentId;
            SubjectId = subjectId;
            Date = date;
            IsPresent = true;
        }

        public Attendance() { }

        public void MarkAbsent(string reason)
        {
            IsPresent = false;
            AbsenceReason = reason ?? "";
        }
    }
}