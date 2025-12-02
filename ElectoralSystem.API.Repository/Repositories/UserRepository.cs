using ElectoralSystem.API.Repository.Context;
using ElectoralSystem.API.Repository.Entities;
using ElectoralSystem.API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ElectoralSystem.API.Repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SqlContext context) : base(context)
        { }

        public async Task<User?> GetByLoginAsync(string login)
        {
            return await Context.Set<User>()
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Login == login);
        }
    }
}
