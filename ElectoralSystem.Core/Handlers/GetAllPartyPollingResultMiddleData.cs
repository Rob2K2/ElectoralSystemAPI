using ElectoralSystem.API.Repository.Entities;
using MediatR;

namespace ElectoralSystem.API.Core.Handlers
{
    public class GetAllPartyPollingResultMiddleData : IRequest<IEnumerable<PartyPollingResult>> 
    {

    }
}

