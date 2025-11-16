using ElectoralSystem.API.Repository.Entities;
using MediatR;

namespace ElectoralSystem.API.Core.Handlers
{
    public class DeletePoliticalPartyMiddleData : IRequest<int>
    {
        public PoliticalParty _PoliticalParty { get; }

        public DeletePoliticalPartyMiddleData(PoliticalParty politicalParty)
        {
            _PoliticalParty = politicalParty ;
        }
    }
}
