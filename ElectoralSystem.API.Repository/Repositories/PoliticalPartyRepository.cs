using ElectoralSystem.API.Repository.Context;
using ElectoralSystem.API.Repository.Entities;
using ElectoralSystem.API.Repository.Interfaces;

namespace ElectoralSystem.API.Repository.Repositories
{
    public class PoliticalPartyRepository : BaseRepository<PoliticalParty>, IPoliticalPartyRepository
    {
        public PoliticalPartyRepository(SqlContext context) : base(context)
        { }
    }
}
