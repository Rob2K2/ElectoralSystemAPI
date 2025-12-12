using ElectoralSystem.API.Repository.Context;
using ElectoralSystem.API.Repository.Entities;
using ElectoralSystem.API.Repository.Interfaces;

namespace ElectoralSystem.API.Repository.Repositories
{
    public class ChangeHistoryRepository : BaseRepository<ChangeHistory>, IChangeHistoryRepository
    {
        public ChangeHistoryRepository(SqlContext context) : base(context)
        {
        }
    }
}
