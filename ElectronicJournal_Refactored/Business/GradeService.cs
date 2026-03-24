using System.Collections.Generic;
using ElectronicJournal.Interfaces;
using ElectronicJournal.Models;

namespace ElectronicJournal.Business
{
    public class GradeService
    {
        private IGradeRepository _gradeRepository;
        private IStudentRepository _studentRepository;
        private ISubjectRepository _subjectRepository;
        private IAverageStrategy _strategy;

        public GradeService(IGradeRepository gradeRepo, IStudentRepository studentRepo, ISubjectRepository subjectRepo)
        {
            _gradeRepository = gradeRepo;
            _studentRepository = studentRepo;
            _subjectRepository = subjectRepo;
            _strategy = new SimpleAverageStrategy();
        }

        public void SetStrategy(IAverageStrategy strategy)
        {
            _strategy = strategy;
        }

        public string GetStrategyName()
        {
            if (_strategy is SimpleAverageStrategy)
                return "Проста (Simple)";
            else if (_strategy is WeightedAverageStrategy)
                return "Зважена (Weighted)";
            else
                return "Невідома";
        }

        public List<Grade> GetGradesByStudent(int studentId)
        {
            return _gradeRepository.GetByStudent(studentId);
        }

        public void AddGrade(Grade grade)
        {
            if (grade == null)
                throw new System.ArgumentNullException(nameof(grade));
            _gradeRepository.Add(grade);
        }

        public void DeleteGrade(int id)
        {
            _gradeRepository.Delete(id);
        }

        public float GetStudentAverage(int studentId, int subjectId)
        {
            return _gradeRepository.GetAverage(studentId, subjectId);
        }
    }
}