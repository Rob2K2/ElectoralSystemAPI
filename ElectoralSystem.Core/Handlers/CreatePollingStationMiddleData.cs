using ElectoralSystem.API.Repository.Entities;
using MediatR;

namespace ElectoralSystem.API.Core.Handlers
{
    public class CreatePollingStationMiddleData : IRequest<PollingStation>
    {
        public PollingStation PollingStation { get; set; }

        public CreatePollingStationMiddleData(PollingStation pollingStation)
        {
            PollingStation = pollingStation;
        }
    }
}

