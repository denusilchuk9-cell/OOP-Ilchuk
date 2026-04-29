using System;
using System.Collections.Generic;
using FitnessTrackerApp.Domain.Entities;

namespace FitnessTrackerApp.Domain.Interfaces
{
    public interface IWorkoutRepository
    {
        void Add(Workout workout);
        void Delete(Guid id);
        Workout GetById(Guid id);
        IEnumerable<Workout> GetByUserId(Guid userId);
        void Save();
        void Load();
    }
}