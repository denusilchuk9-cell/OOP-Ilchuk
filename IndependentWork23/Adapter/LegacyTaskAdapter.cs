using IndependentWork23.Models;

namespace IndependentWork23.Adapter
{
    public class LegacyTaskAdapter : ITaskExecutor
    {
        private LegacyTaskRunner _legacyTaskRunner;

        public LegacyTaskAdapter(LegacyTaskRunner legacyTaskRunner)
        {
            _legacyTaskRunner = legacyTaskRunner;
        }

        public string ExecuteTask(TaskData task)
        {
            string taskData = $"{task.Description}|Priority:Normal";

            string result = _legacyTaskRunner.RunTask(task.Id, task.Title, taskData, task.AssignedTo);

            if (result.StartsWith("SUCCESS"))
            {
                task.IsCompleted = true;
            }

            return $"[ADAPTER] Converted modern Task to legacy format\n[ADAPTER] Result: {result}";
        }
    }
}