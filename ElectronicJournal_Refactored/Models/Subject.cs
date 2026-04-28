using System;

namespace ElectronicJournal.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TeacherName { get; set; }
        public int Hours { get; set; }
        public string ControlForm { get; set; }

        public Subject(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Назва предмета не може бути порожньою");
            Name = name;
        }

        public Subject() { }

        public string GetInfo()
        {
            return $"{Name} - {TeacherName} - {Hours} год. - {ControlForm}";
        }
    }
}