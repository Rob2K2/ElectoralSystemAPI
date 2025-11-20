using ElectoralSystem.API.Repository.Context;
using ElectoralSystem.API.Repository.Entities;
using ElectoralSystem.API.Repository.Interfaces;

namespace ElectoralSystem.API.Repository.Repositories
{
    public class PollingStationRepository : BaseRepository<PollingStation>, IPollingStationRepository
    {
        public PollingStationRepository(SqlContext context) : base(context)
        { }
    }
}

