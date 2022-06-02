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

        public virtual void Delete(TEntity entityToDelete)
        {
            dbSet.Remove(entityToDelete);
            Save();
        }

        public virtual void Delete(object id)
        {
            TEntity entity = dbSet.Find(id);
            Delete(entity);
        }

        public virtual TEntity GetByID(object id)
        {
            var res = dbSet.Find(id);
            return res;
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
            Save();
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
