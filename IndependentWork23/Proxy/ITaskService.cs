using IndependentWork23.Models;

namespace IndependentWork23.Proxy
{
    public interface ITaskService
    {
        TaskData GetTask(int id);
        string CompleteTask(int id);
    }
}