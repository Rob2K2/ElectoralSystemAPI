using ElectoralSystem.API.Repository.Entities;
using MediatR;

namespace ElectoralSystem.API.Core.Handlers
{
    public class GetIdPollingStationMiddleData : IRequest<PollingStation>
    {
        public Guid PollingStationId { get; }

        public GetIdPollingStationMiddleData(Guid pollingStationId)
        {
            PollingStationId = pollingStationId;
        }
    }
}

