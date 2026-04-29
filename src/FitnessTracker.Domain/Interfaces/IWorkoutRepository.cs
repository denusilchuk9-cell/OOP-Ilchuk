using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Domain.Interfaces
{
    public interface IWorkoutRepository
    {
        void Add(Workout workout);
        void Update(Workout workout);
        void Delete(Guid id);
        Workout GetById(Guid id);
        IEnumerable<Workout> GetByUserId(Guid userId);
        IEnumerable<Workout> GetByDateRange(Guid userId, DateTime start, DateTime end);
        
        Task SaveAsync(CancellationToken cancellationToken = default);
        Task LoadAsync(CancellationToken cancellationToken = default);
    }
}