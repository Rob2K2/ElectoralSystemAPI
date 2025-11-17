using ElectoralSystem.API.Repository.Context;
using ElectoralSystem.API.Repository.Entities;
using ElectoralSystem.API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace ElectoralSystem.API.Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntityBase
    {
        private readonly SqlContext _context;

        protected SqlContext Context { get { return _context; } }

        public BaseRepository(SqlContext context)
        {
            _context = context;
        }
        public async Task<T> CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> lambda)
        {
            return await _context.Set<T>().AsNoTracking().Where(lambda).ToListAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            var entry = _context.Entry(entity);
            _context.Set<T>().Attach(entity);
            entry.State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
