using Microsoft.EntityFrameworkCore;
using Task9.Data;

namespace Task9.Services
{
    public class TaskService : ITaskService
    {
        private readonly TaskContext _context;

        public TaskService(TaskContext context)
        {
            _context = context;
        }

        public async Task<List<Models.Task>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }
        public async Task<Models.Task> GetTaskById(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<Models.Task> CreateTask(Models.TaskViewModel task)
        {
            var _task = new Models.Task()
            {
                Name = task.Name,
                Description = task.Description,
                Status = task.Status,
                CreatorId = task.CreatorId,
                PerformerId = task.PerformerId,
            };
            await _context.AddAsync(_task);
            await _context.SaveChangesAsync();
            return _task;
        }

        public async Task UpdateTask(int id, Models.TaskViewModel task)
        {
            var _task = await _context.Tasks.FindAsync(id);
            _task.Name = task.Name;
            _task.Description = task.Description;
            _task.Status = task.Status;
            _task.CreatorId = task.CreatorId;
            _task.PerformerId = task.PerformerId;
            _context.Update(_task);
            await _context.SaveChangesAsync();
        }
        public async Task<Models.Task> DeleteTask(int id)
        {
            var _task = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(_task);
            await _context.SaveChangesAsync();
            return _task;
        }

    }
}
