using System.Linq.Expressions;
using ElectoralSystem.API.Repository.Entities;

namespace ElectoralSystem.API.Repository.Interfaces
{
    public interface IBaseRepository<T> : IDisposable where T : class, IEntityBase 
    {
        Task<T> CreateAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> lambda);
    }
}
