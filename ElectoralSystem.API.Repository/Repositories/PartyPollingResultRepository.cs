using ElectoralSystem.API.Repository.Context;
using ElectoralSystem.API.Repository.Entities;
using ElectoralSystem.API.Repository.Interfaces;

namespace ElectoralSystem.API.Repository.Repositories
{
    public class PartyPollingResultRepository : BaseRepository<PartyPollingResult>, IPartyPollingResultRepository
    {
        public PartyPollingResultRepository(SqlContext context) : base(context)
        { }
    }
}

