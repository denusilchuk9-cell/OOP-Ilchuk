using IndependentWork23.Models;

namespace IndependentWork23.Adapter
{
    public interface ITaskExecutor
    {
        string ExecuteTask(TaskData task);
    }
}