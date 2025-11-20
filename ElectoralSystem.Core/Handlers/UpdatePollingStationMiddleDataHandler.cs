using ElectoralSystem.API.Core.Handlers;
using ElectoralSystem.API.Error;
using ElectoralSystem.API.Error.Bussiness;
using ElectoralSystem.API.Error.Logs;
using ElectoralSystem.API.Repository.Interfaces;
using MediatR;
using System.Linq;

namespace ElectoralSystem.Core.Handlers
{
    public class UpdatePollingStationMiddleDataHandler : IRequestHandler<UpdatePollingStationMiddleData, int>
    {
        private readonly IPollingStationRepository _repository;
        private readonly ILogger _logger;

        public UpdatePollingStationMiddleDataHandler(IPollingStationRepository repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<int> Handle(UpdatePollingStationMiddleData request, CancellationToken cancellationToken)
        {
            var existingStation = (await _repository.GetAsync(x => x.Id == request.PollingStation.Id)).FirstOrDefault();

            if (existingStation is null)
            {
                throw new PollingStationIdNotFoundException(request.PollingStation.Id);
            }

            var duplicatedNumber = (await _repository
                .GetAsync(x => x.Number == request.PollingStation.Number && x.Id != request.PollingStation.Id))
                .FirstOrDefault();

            if (duplicatedNumber is not null)
            {
                _logger.Log(Severity.WARNING, $"Attempt to update polling station to duplicated number '{request.PollingStation.Number}'.");
                throw new PollingStationNumberAlreadyExistsException(request.PollingStation.Number);
            }

            return await _repository.UpdateAsync(request.PollingStation);
        }
    }
}

