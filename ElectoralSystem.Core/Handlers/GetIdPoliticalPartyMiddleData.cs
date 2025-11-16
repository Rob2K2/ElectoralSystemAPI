using ElectoralSystem.API.Repository.Entities;
using MediatR;

namespace ElectoralSystem.API.Core.Handlers
{
    public class GetIdPoliticalPartyMiddleData : IRequest<PoliticalParty>
    {
        public Guid PoliticalPartyId { get; }

        public GetIdPoliticalPartyMiddleData(Guid politicalPartyId)
        {
            PoliticalPartyId = politicalPartyId;
        }
    }
}
