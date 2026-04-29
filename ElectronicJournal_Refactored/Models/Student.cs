using System;

namespace ElectronicJournal.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string RecordBookNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Student(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("Ім'я не може бути порожнім");
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Прізвище не може бути порожнім");

            FirstName = firstName;
            LastName = lastName;
        }

        public Student() { }

        public string GetFullName()
        {
            return $"{LastName} {FirstName} {MiddleName}";
        }

        public bool Validate()
        {
            return !string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName);
        }
    }
}