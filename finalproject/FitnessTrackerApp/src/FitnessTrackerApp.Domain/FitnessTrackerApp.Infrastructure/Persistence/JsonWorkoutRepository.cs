using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using FitnessTrackerApp.Domain.Entities;
using FitnessTrackerApp.Domain.Interfaces;

namespace FitnessTrackerApp.Infrastructure.Persistence
{
    public class JsonWorkoutRepository : IWorkoutRepository
    {
        private readonly string _filePath;
        private List<Workout> _workouts;

        public JsonWorkoutRepository(string filePath = "workouts.json")
        {
            _filePath = filePath;
            _workouts = new List<Workout>();
            Load();
        }

        public void Add(Workout workout) => _workouts.Add(workout);
        public void Delete(Guid id) => _workouts.RemoveAll(w => w.Id == id);
        public Workout GetById(Guid id) => _workouts.FirstOrDefault(w => w.Id == id);
        public IEnumerable<Workout> GetByUserId(Guid userId) => _workouts.Where(w => w.UserId == userId);

        public void Save()
        {
            var json = JsonSerializer.Serialize(_workouts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        public void Load()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                _workouts = JsonSerializer.Deserialize<List<Workout>>(json) ?? new List<Workout>();
            }
        }
    }
}