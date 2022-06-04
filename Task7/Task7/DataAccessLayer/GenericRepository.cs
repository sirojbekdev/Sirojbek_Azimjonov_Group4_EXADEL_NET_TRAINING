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

        public virtual async Task Delete(TEntity entityToDelete)
        {
            dbSet.Remove(entityToDelete);
            await Save();
        }

        public virtual async Task Delete(object id)
        {
            TEntity entity = await dbSet.FindAsync(id);
            await Delete(entity);
        }

        public virtual async Task<TEntity> GetByID(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task Insert(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            await Save();
        }

        public virtual async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity entityToUpdate)
        {
            dbSet.Update(entityToUpdate);
            await Save();
        }
    }
}
