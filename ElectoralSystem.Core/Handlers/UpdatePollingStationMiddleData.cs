using ElectoralSystem.API.Repository.Entities;
using MediatR;

namespace ElectoralSystem.API.Core.Handlers
{
    public class UpdatePollingStationMiddleData : IRequest<int>
    {
        public PollingStation PollingStation { get; set; }

        public UpdatePollingStationMiddleData(PollingStation pollingStation)
        {
            PollingStation = pollingStation;
        }
    }
}

