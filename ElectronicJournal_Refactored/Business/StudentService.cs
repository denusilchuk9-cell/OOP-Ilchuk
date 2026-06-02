using System.Collections.Generic;
using ElectronicJournal.Interfaces;
using ElectronicJournal.Models;

namespace ElectronicJournal.Business
{
    public class StudentService
    {
        private IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepo) => _studentRepository = studentRepo;
        public List<Student> GetAllStudents() => _studentRepository.GetAll();
        public Student GetStudentById(int id) => _studentRepository.GetById(id);
        public void AddStudent(Student student) => _studentRepository.Add(student);
        public void UpdateStudent(Student student) => _studentRepository.Update(student);
        public void DeleteStudent(int id) => _studentRepository.Delete(id);
        public List<Student> SearchStudents(string search) => _studentRepository.FindByName(search);
        public bool ValidateStudent(Student student) => student.Validate();
    }
}