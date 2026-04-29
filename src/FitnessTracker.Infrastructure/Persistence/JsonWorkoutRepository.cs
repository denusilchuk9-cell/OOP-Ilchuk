using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FitnessTracker.Domain.Entities;
using FitnessTracker.Domain.Interfaces;

namespace FitnessTracker.Infrastructure.Persistence
{
    public class JsonWorkoutRepository : IWorkoutRepository
    {
        private readonly string _filePath;
        private List<Workout> _workouts;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public JsonWorkoutRepository(string filePath = "workouts.json")
        {
            _filePath = filePath;
            _workouts = new List<Workout>();
            LoadAsync().GetAwaiter().GetResult();
        }

        public void Add(Workout workout)
        {
            _workouts.Add(workout);
        }

        public void Update(Workout workout)
        {
            var index = _workouts.FindIndex(w => w.Id == workout.Id);
            if (index != -1)
                _workouts[index] = workout;
        }

        public void Delete(Guid id)
        {
            _workouts.RemoveAll(w => w.Id == id);
        }

        public Workout GetById(Guid id)
        {
            return _workouts.FirstOrDefault(w => w.Id == id);
        }

        public IEnumerable<Workout> GetByUserId(Guid userId)
        {
            return _workouts.Where(w => w.UserId == userId);
        }

        public IEnumerable<Workout> GetByDateRange(Guid userId, DateTime start, DateTime end)
        {
            return _workouts.Where(w => w.UserId == userId && w.Date >= start && w.Date <= end);
        }

        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            await _semaphore.WaitAsync(cancellationToken);
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                var json = JsonSerializer.Serialize(_workouts, options);
                await File.WriteAllTextAsync(_filePath, json, cancellationToken);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task LoadAsync(CancellationToken cancellationToken = default)
        {
            if (File.Exists(_filePath))
            {
                var json = await File.ReadAllTextAsync(_filePath, cancellationToken);
                _workouts = JsonSerializer.Deserialize<List<Workout>>(json) ?? new List<Workout>();
            }
        }
    }
}