using System.Collections.Generic;
using System.Linq;
using ElectronicJournal.Interfaces;
using ElectronicJournal.Models;

namespace ElectronicJournal.Data
{
    public class StudentRepository : IStudentRepository
    {
        private static List<Student> _students = new List<Student>();
        private static int _nextId = 1;

        public List<Student> GetAll() => _students;

        public Student GetById(int id) => _students.FirstOrDefault(s => s.Id == id);

        public void Add(Student student)
        {
            student.Id = _nextId++;
            _students.Add(student);
        }

        public void Update(Student student)
        {
            var existing = GetById(student.Id);
            if (existing != null)
            {
                existing.FirstName = student.FirstName;
                existing.LastName = student.LastName;
                existing.MiddleName = student.MiddleName;
                existing.RecordBookNumber = student.RecordBookNumber;
                existing.Email = student.Email;
                existing.Phone = student.Phone;
            }
        }

        public void Delete(int id)
        {
            var s = GetById(id);
            if (s != null) _students.Remove(s);
        }

        public List<Student> FindByName(string name)
        {
            return _students.Where(s =>
                s.FirstName.Contains(name) ||
                s.LastName.Contains(name) ||
                s.MiddleName.Contains(name)).ToList();
        }
    }
}