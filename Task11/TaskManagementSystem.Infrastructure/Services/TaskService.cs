using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.Data;

namespace TaskManagementSystem.Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly TaskDbContext _context;

        public TaskService(IUnitOfWork unitOfWork, TaskDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task<TaskItem> CreateTask(TaskDto task)
        {
            var _task = new TaskItem()
            {
                Name = task.Name,
                Description = task.Description,
                Status = task.Status,
                CreatorId = task.CreatorId,
                PerformerId = task.PerformerId,
            };
            if (_task.PerformerId == null)
            {
                var creator = await _unitOfWork.Users.GetById(_task.CreatorId);
                _task.Description += $". Creator: {creator.FullName}.Created: {DateTime.Now}. NO Performer";
            }
            else
            {
                var creator = await _unitOfWork.Users.GetById(_task.CreatorId);
                var performer = await _unitOfWork.Users.GetById(_task.PerformerId);
                _task.Description += $". Creator: {creator.FullName}.“Created: {DateTime.Now}. Performer: {performer.FullName}";
            }
            await _unitOfWork.Tasks.Add(_task);
            await _unitOfWork.SaveAsync();
            return _task;
        }

        public async Task<TaskItem> DeleteTask(int id)
        {
            var _task = await _unitOfWork.Tasks.GetById(id);
            _context.Tasks.Remove(_task);
            await _unitOfWork.SaveAsync();
            return _task;
        }

        public Task<TaskItem> GetTaskById(int id)
        {
            return _unitOfWork.Tasks.GetById(id);
        }

        public async Task<List<TaskItem>> GetTasks()
        {
            return await _unitOfWork.Tasks.GetAll();
        }

        public async Task UpdateTask(int id, TaskDto task)
        {
            var _task = await _unitOfWork.Tasks.GetById(id);
            _task.Name = task.Name;
            _task.Description = task.Description;
            _task.Status = task.Status;
            _task.CreatorId = task.CreatorId;
            _task.PerformerId = task.PerformerId;
            await _unitOfWork.Tasks.Update(id,_task);
            await _unitOfWork.SaveAsync();
        }
    }
}
