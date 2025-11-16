using ElectoralSystem.API.Repository.Entities;
using MediatR;

namespace ElectoralSystem.API.Core.Handlers
{
    public class GetAllPoliticalPartyMiddleData : IRequest<IEnumerable<PoliticalParty>> 
    {

    }
}
