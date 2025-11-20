using ElectoralSystem.API.Repository.Entities;
using MediatR;

namespace ElectoralSystem.API.Core.Handlers
{
    public class GetAllPollingStationMiddleData : IRequest<IEnumerable<PollingStation>> 
    {

    }
}

