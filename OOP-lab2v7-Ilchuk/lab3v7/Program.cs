using System;
using Lab2;

namespace Lab2App
{
    class Program
    {
        static void Main()
        {
            var group = new StudentGroup();

            group += new Student("Іван Петренко", 20);
            group += new Student("Олена Коваль", 21);
            group += new Student("Марко Лисенко", 22);

            group.PrintAll();

            Console.WriteLine();
            var found = group["Олена Коваль"];
            Console.WriteLine(found != null ? $"Знайдено: {found}" : "Студента не знайдено");

            Console.WriteLine();
            group -= new Student("Іван Петренко", 20);
            group.PrintAll();
        }
    }
}