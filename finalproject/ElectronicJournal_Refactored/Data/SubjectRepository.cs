using System.Collections.Generic;
using System.Linq;
using ElectronicJournal.Interfaces;
using ElectronicJournal.Models;

namespace ElectronicJournal.Data
{
    public class SubjectRepository : ISubjectRepository
    {
        private static List<Subject> _subjects = new List<Subject>();
        private static int _nextId = 1;

        public List<Subject> GetAll() => _subjects;

        public Subject GetById(int id) => _subjects.FirstOrDefault(s => s.Id == id);

        public void Add(Subject subject)
        {
            subject.Id = _nextId++;
            _subjects.Add(subject);
        }

        public void Update(Subject subject)
        {
            var existing = GetById(subject.Id);
            if (existing != null)
            {
                existing.Name = subject.Name;
                existing.TeacherName = subject.TeacherName;
                existing.Hours = subject.Hours;
                existing.ControlForm = subject.ControlForm;
            }
        }

        public void Delete(int id)
        {
            var s = GetById(id);
            if (s != null) _subjects.Remove(s);
        }

        public List<Subject> GetByTeacher(string teacher)
        {
            return _subjects.Where(s => s.TeacherName.Contains(teacher)).ToList();
        }
    }
}