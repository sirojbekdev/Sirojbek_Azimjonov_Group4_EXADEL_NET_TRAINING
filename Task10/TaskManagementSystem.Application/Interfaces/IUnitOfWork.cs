using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Role> Roles { get; }
        IGenericRepository<User> Users { get; }
        IGenericRepository<TaskItem> Tasks { get; }
        Task SaveAsync();
        void Dispose();
    }
}
