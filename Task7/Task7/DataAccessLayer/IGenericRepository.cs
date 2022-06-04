namespace Task7.DataAccessLayer
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task Delete(TEntity entityToDelete);
        Task Delete(object id);
        Task<TEntity> GetByID(object id);
        Task Insert(TEntity entity);
        Task Update(TEntity entityToUpdate);
        Task Save();
    }
}
