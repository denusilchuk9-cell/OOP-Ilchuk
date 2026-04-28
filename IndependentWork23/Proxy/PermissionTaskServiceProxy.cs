using System;
using System.Collections.Generic;
using IndependentWork23.Models;

namespace IndependentWork23.Proxy
{
    public class PermissionTaskServiceProxy : ITaskService
    {
        private RealTaskService _realService;
        private string _currentUser;
        private Dictionary<int, TaskData> _cache;
        private Dictionary<string, int> _requestCount;
        private const int MAX_REQUESTS_PER_MINUTE = 5;

        public PermissionTaskServiceProxy(string currentUser)
        {
            _currentUser = currentUser;
            _realService = new RealTaskService();
            _cache = new Dictionary<int, TaskData>();
            _requestCount = new Dictionary<string, int>();

            Console.WriteLine($"[PROXY] Created for user: {currentUser}");
            Console.WriteLine($"[PROXY] Rate limit: {MAX_REQUESTS_PER_MINUTE} requests per minute");
        }

        private bool HasPermission(string action)
        {
            var allowedUsers = new Dictionary<string, List<string>>
            {
                { "GetTask", new List<string> { "admin", "developer", "viewer", "security" } },
                { "CompleteTask", new List<string> { "admin", "developer", "security" } }
            };

            if (!allowedUsers.ContainsKey(action))
            {
                return false;
            }

            bool hasPermission = allowedUsers[action].Contains(_currentUser);

            if (!hasPermission)
            {
                Console.WriteLine($"[PROXY] ACCESS DENIED: User '{_currentUser}' cannot perform '{action}'");
            }
            else
            {
                Console.WriteLine($"[PROXY] ACCESS GRANTED: User '{_currentUser}' can perform '{action}'");
            }

            return hasPermission;
        }

        private bool CheckRateLimit()
        {
            string minute = DateTime.Now.ToString("yyyy-MM-dd-HH-mm");

            if (!_requestCount.ContainsKey(minute))
            {
                _requestCount[minute] = 0;
            }

            if (_requestCount[minute] >= MAX_REQUESTS_PER_MINUTE)
            {
                Console.WriteLine($"[PROXY] RATE LIMIT EXCEEDED: {MAX_REQUESTS_PER_MINUTE} requests per minute");
                return false;
            }

            _requestCount[minute]++;
            Console.WriteLine($"[PROXY] Request count this minute: {_requestCount[minute]}/{MAX_REQUESTS_PER_MINUTE}");
            return true;
        }

        public TaskData GetTask(int id)
        {
            Console.WriteLine($"\n[PROXY] GetTask({id}) called by user '{_currentUser}'");

            if (!HasPermission("GetTask"))
            {
                return null;
            }

            if (!CheckRateLimit())
            {
                return null;
            }

            if (_cache.ContainsKey(id))
            {
                Console.WriteLine($"[PROXY] CACHE HIT: Returning cached task {id}");
                return _cache[id];
            }

            Console.WriteLine($"[PROXY] CACHE MISS: Fetching from real service");
            TaskData task = _realService.GetTask(id);

            if (task != null)
            {
                _cache[id] = task;
                Console.WriteLine($"[PROXY] Task {id} added to cache");
            }

            return task;
        }

        public string CompleteTask(int id)
        {
            Console.WriteLine($"\n[PROXY] CompleteTask({id}) called by user '{_currentUser}'");

            if (!HasPermission("CompleteTask"))
            {
                return "ERROR: Access denied - insufficient permissions";
            }

            if (!CheckRateLimit())
            {
                return "ERROR: Rate limit exceeded - try again later";
            }

            string result = _realService.CompleteTask(id);

            if (_cache.ContainsKey(id))
            {
                _cache.Remove(id);
                Console.WriteLine($"[PROXY] Task {id} removed from cache due to modification");
            }

            return result;
        }

        public void ShowCache()
        {
            Console.WriteLine($"\n[PROXY] Cache contains {_cache.Count} items:");
            foreach (var item in _cache)
            {
                Console.WriteLine($"  - Task {item.Key}: {item.Value.Title}");
            }
        }
    }
}