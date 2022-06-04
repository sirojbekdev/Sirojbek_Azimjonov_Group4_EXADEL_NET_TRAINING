using Microsoft.EntityFrameworkCore;
using Task7.Data;

namespace Task7.DataAccessLayer
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private AppDbContext _context;
        private DbSet<TEntity> dbSet;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual async Task DeleteAsync(TEntity entityToDelete)
        {
            dbSet.Remove(entityToDelete);
            await SaveAsync();
        }

        public virtual async Task DeleteAsync(object id)
        {
            TEntity entity = await dbSet.FindAsync(id);
            await DeleteAsync(entity);
        }

        public async Task<TEntity> GetByIDAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            await SaveAsync();
        }

        public virtual async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entityToUpdate)
        {
            dbSet.Update(entityToUpdate);
            await SaveAsync();
        }
    }
}
