using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Domain.Models;

namespace TaskManagementSystem.Application.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
    }
}
