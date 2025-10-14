using System;
using System.Collections.Generic;

namespace Lab2
{
    public class StudentGroup
    {
        private readonly List<Student> students = new List<Student>();

        public Student this[string fullName]
        {
            get => students.Find(s => s.FullName == fullName);
        }

        public static StudentGroup operator +(StudentGroup group, Student student)
        {
            if (student != null && group.students.Find(s => s.FullName == student.FullName) == null)
                group.students.Add(student);
            return group;
        }

        public static StudentGroup operator -(StudentGroup group, Student student)
        {
            if (student == null) return group;
            group.students.RemoveAll(s => s.FullName == student.FullName);
            return group;
        }

        public void PrintAll()
        {
            Console.WriteLine("Список студентів:");
            if (students.Count == 0)
            {
                Console.WriteLine("  (пусто)");
                return;
            }
            foreach (var s in students)
                Console.WriteLine($"  {s}");
        }
    }
}