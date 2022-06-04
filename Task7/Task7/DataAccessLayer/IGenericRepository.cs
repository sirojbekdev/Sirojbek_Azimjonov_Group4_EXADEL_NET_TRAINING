namespace Task7.DataAccessLayer
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task DeleteAsync(TEntity entityToDelete);
        Task DeleteAsync(object id);
        Task<TEntity> GetByIDAsync(object id);
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entityToUpdate);
        Task SaveAsync();
    }
}
