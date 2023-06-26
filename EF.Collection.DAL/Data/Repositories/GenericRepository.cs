using EFCatalogs.DAL.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EFCatalogs.DAL.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                return await _dbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> AddAsync(T entity)
        {
            _dbSet.Add(entity);
            await _dbContext.SaveChangesAsync();
            // Assuming the primary key property is named "Id"
            var primaryKeyValue = GetPrimaryKeyValue(entity);
            return Convert.ToInt32(primaryKeyValue);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        private object GetPrimaryKeyValue(T entity)
        {
            var entityType = typeof(T);
            var primaryKeyProperty = entityType.GetProperty("Id"); // Assuming the primary key property is named "Id"
            if (primaryKeyProperty != null)
            {
                return primaryKeyProperty.GetValue(entity);
            }
            throw new InvalidOperationException("Primary key property not found.");
        }
    }
}
