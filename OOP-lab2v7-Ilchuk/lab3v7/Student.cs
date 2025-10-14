namespace Lab2
{
    public class Student
    {
        public string FullName { get; set; }
        public int Age { get; set; }

        public Student() { }

        public Student(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }

        public override string ToString() => $"{FullName}, {Age} років";

        public static bool operator ==(Student a, Student b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            return a.FullName == b.FullName && a.Age == b.Age;
        }

        public static bool operator !=(Student a, Student b) => !(a == b);

        public override bool Equals(object obj) => obj is Student s && this == s;

        public override int GetHashCode() => (FullName ?? string.Empty).GetHashCode() ^ Age.GetHashCode();
    }
}