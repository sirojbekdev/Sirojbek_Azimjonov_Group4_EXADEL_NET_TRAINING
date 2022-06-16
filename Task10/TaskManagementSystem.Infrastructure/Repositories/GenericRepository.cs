using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Infrastructure.Data;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private TaskDbContext _context;
        private DbSet<T> dbSet;

        public GenericRepository(TaskDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }
        public async Task<T> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<List<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> Delete(object id)
        {
            var item = await GetById(id);
            dbSet.Remove(item);
            return item;
        }

        public async Task<T> GetById(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<T> Update(object id, T entity)
        {
            var item = await GetById(id);
            dbSet.Update(item);
            return item;
        }
    }
}
