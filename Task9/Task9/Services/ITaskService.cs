using Task9.Models;

namespace Task9.Services
{
    public interface ITaskService
    {
        Task<Models.Task> CreateTask(TaskViewModel task);
        Task<Models.Task> DeleteTask(int id);
        Task<Models.Task> GetTaskById(int id);
        Task<List<Models.Task>> GetTasks();
        System.Threading.Tasks.Task UpdateTask(int id, TaskViewModel task);
    }
}