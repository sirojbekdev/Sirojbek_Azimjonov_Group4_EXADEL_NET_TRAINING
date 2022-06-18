namespace TaskManagementSystem.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(object id);
        Task<T> Add(T entity);
        Task<T> Delete(object id);
        Task<T> Update(object id, T entity);
    }
}
