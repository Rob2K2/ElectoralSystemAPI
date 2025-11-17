using ElectoralSystem.API.Repository.Entities;
using MediatR;

namespace ElectoralSystem.API.Core.Handlers
{
    public class UpdatePoliticalPartyMiddleData : IRequest<int>
    {
        public PoliticalParty PoliticalParty { get; set; }

        public UpdatePoliticalPartyMiddleData(PoliticalParty politicalParty)
        {
            PoliticalParty = politicalParty;
        }
    }
}

