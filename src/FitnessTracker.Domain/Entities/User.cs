using System;

namespace FitnessTracker.Domain.Entities
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
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Weight = weight > 0 ? weight : throw new ArgumentException("Weight must be positive");
            Age = age > 0 && age < 120 ? age : throw new ArgumentException("Invalid age");
            Gender = gender;
        }

        public void UpdateWeight(double newWeight)
        {
            if (newWeight <= 0)
                throw new ArgumentException("Weight must be positive");
            Weight = newWeight;
        }
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }
}