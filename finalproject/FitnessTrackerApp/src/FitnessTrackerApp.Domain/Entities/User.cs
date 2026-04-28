using System;

namespace FitnessTrackerApp.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int Age { get; private set; }
        public Gender Gender { get; private set; }

        public User(string name, double weight, int age, Gender gender)
        {
            Id = Guid.NewGuid();
            Name = name;
            Weight = weight;
            Age = age;
            Gender = gender;
        }
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }
}