using ElectoralSystem.API.Repository.Entities;
using MediatR;

namespace ElectoralSystem.API.Core.Handlers
{
    public class DeletePollingStationMiddleData : IRequest<int>
    {
        public PollingStation _PollingStation { get; }

        public DeletePollingStationMiddleData(PollingStation pollingStation)
        {
            _PollingStation = pollingStation;
        }
    }
}

