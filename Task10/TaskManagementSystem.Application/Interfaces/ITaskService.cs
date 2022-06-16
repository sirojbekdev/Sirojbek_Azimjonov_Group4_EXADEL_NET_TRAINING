using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Interfaces
{
    public interface ITaskService
    {
        Task<TaskItem> CreateTask(TaskDto task);
        Task<TaskItem> DeleteTask(int id);
        Task<TaskItem> GetTaskById(int id);
        Task<List<TaskItem>> GetTasks();
        Task UpdateTask(int id, TaskDto task);
    }
}
