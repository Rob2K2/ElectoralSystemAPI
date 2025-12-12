using ElectoralSystem.API.Repository.Context;
using ElectoralSystem.API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ElectoralSystem.API.Repository.Repositories
{
    public class ReadRepository : IReadRepository
    {
        private readonly SqlContext _context;

        public ReadRepository(SqlContext context)
        {
            _context = context;
        }

        public async Task<object?> GetByIdAsync(Type entityType, Guid id)
        {
            var entityTypeInModel = _context.Model.FindEntityType(entityType);

            if(entityTypeInModel == null)
                return null;

            var dbSet = typeof(DbContext)
                 .GetMethod(nameof(DbContext.Set), 1, Type.EmptyTypes)!
                 .MakeGenericMethod(entityType)
                 .Invoke(_context, null);


            if (dbSet == null)
                return null;

            var queryable = (IQueryable<object>)dbSet;

            var entity = await queryable.AsNoTracking().Where(e => EF.Property<Guid>(e, "Id") == id).FirstOrDefaultAsync();

            return entity;
        }
    }
}
