using ElectoralSystem.API.Error.Bussiness;
using ElectoralSystem.API.Repository.Entities;
using ElectoralSystem.API.Repository.Interfaces;
using MediatR;
using System.Linq;

namespace ElectoralSystem.API.Core.Handlers
{
    public class GetIdPollingStationMiddleDataHandler : IRequestHandler<GetIdPollingStationMiddleData, PollingStation>
    {
        private readonly IPollingStationRepository _repository;

        public GetIdPollingStationMiddleDataHandler(IPollingStationRepository repository)
        {
            _repository = repository;
        }
        public async Task<PollingStation?> Handle(GetIdPollingStationMiddleData request, CancellationToken cancellationToken)
        {
            var response = (await _repository.GetAsync(x => x.Id.Equals(request.PollingStationId))).FirstOrDefault();

            if (response is null)
            {
                throw new PollingStationIdNotFoundException(request.PollingStationId);
            }
            return response;
        }
    }
}

