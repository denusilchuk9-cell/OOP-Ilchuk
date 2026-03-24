using ElectronicJournal.Interfaces;

namespace ElectronicJournal.Data
{
    public static class RepositoryFactory
    {
        public static IStudentRepository CreateStudentRepository() => new StudentRepository();
        public static ISubjectRepository CreateSubjectRepository() => new SubjectRepository();
        public static IGradeRepository CreateGradeRepository() => new GradeRepository();
        public static IAttendanceRepository CreateAttendanceRepository() => new AttendanceRepository();
    }
}