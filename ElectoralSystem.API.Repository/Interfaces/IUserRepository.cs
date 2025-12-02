using ElectoralSystem.API.Repository.Entities;

namespace ElectoralSystem.API.Repository.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByLoginAsync(string username);
    }
}
