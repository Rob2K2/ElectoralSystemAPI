using ElectoralSystem.API.Repository.Entities;
using ElectoralSystem.API.Repository.Interfaces;
using MediatR;
using System.Linq;

namespace ElectoralSystem.API.Core.Handlers
{
    public class GetAllPollingStationMiddleDataHandler : IRequestHandler<GetAllPollingStationMiddleData, IEnumerable<PollingStation>>
    {
        private readonly IPollingStationRepository _repository;

        public GetAllPollingStationMiddleDataHandler(IPollingStationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PollingStation>> Handle(GetAllPollingStationMiddleData request, CancellationToken cancellationToken)
        {
            var response = await _repository.GetAsync(x => true);

            return response.ToList();
        }
    }
}

