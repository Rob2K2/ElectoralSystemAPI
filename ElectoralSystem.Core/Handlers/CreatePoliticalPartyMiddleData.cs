using ElectoralSystem.API.Repository.Entities;
using MediatR;

namespace ElectoralSystem.API.Core.Handlers
{
    public class CreatePoliticalPartyMiddleData : IRequest<PoliticalParty>
    {
        public PoliticalParty PoliticalParty { get; set; }

        public CreatePoliticalPartyMiddleData(PoliticalParty politicalParty)
        {
            PoliticalParty = politicalParty;
        }
    }
}
