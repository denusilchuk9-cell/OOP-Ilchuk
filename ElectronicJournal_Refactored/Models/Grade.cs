using System;

namespace ElectronicJournal.Models
{
    public class Grade
    {
        private const int PassingThreshold = 60;

        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }
        public string GradeType { get; set; }

        public Grade(int studentId, int subjectId, int value, DateTime date)
        {
            if (studentId <= 0)
                throw new ArgumentException("Невірний ID студента");
            if (subjectId <= 0)
                throw new ArgumentException("Невірний ID предмета");
            if (value < 0 || value > 100)
                throw new ArgumentException("Оцінка має бути від 0 до 100");
            StudentId = studentId;
            SubjectId = subjectId;
            Value = value;
            Date = date;
        }

        public Grade() { }

        public bool IsPassing()
        {
            return Value >= PassingThreshold;
        }
    }
}