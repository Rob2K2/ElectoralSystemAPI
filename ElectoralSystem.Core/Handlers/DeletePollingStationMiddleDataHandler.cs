using ElectoralSystem.API.Error.Bussiness;
using ElectoralSystem.API.Repository.Entities;
using ElectoralSystem.API.Repository.Interfaces;
using MediatR;
using System.Linq;

namespace ElectoralSystem.API.Core.Handlers
{
    public class DeletePollingStationMiddleDataHandler : IRequestHandler<DeletePollingStationMiddleData, int>
    {
        public readonly IPollingStationRepository _repository;

        public DeletePollingStationMiddleDataHandler(IPollingStationRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(DeletePollingStationMiddleData request, CancellationToken cancellationToken)
        {
            var response = (await _repository.GetAsync(x => x.Id == request._PollingStation.Id)).FirstOrDefault();

            if (response is null)
            {
                throw new PollingStationIdNotFoundException(request._PollingStation.Id);
            }

            return await _repository.DeleteAsync(response);
        }
    }
}

