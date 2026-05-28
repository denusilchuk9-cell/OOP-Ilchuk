using System.Collections.Generic;
using ElectronicJournal.Interfaces;
using ElectronicJournal.Models;

namespace ElectronicJournal.Business
{
    public class SubjectService
    {
        private ISubjectRepository _subjectRepository;
        public SubjectService(ISubjectRepository subjectRepo) => _subjectRepository = subjectRepo;
        public List<Subject> GetAllSubjects() => _subjectRepository.GetAll();
        public Subject GetSubjectById(int id) => _subjectRepository.GetById(id);
        public void AddSubject(Subject subject) => _subjectRepository.Add(subject);
        public void UpdateSubject(Subject subject) => _subjectRepository.Update(subject);
        public void DeleteSubject(int id) => _subjectRepository.Delete(id);
    }
}