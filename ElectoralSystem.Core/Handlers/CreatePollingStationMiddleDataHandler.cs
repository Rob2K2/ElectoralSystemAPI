using ElectoralSystem.API.Core.Handlers;
using ElectoralSystem.API.Error;
using ElectoralSystem.API.Error.Bussiness;
using ElectoralSystem.API.Error.Logs;
using ElectoralSystem.API.Repository.Entities;
using ElectoralSystem.API.Repository.Interfaces;
using MediatR;
using System.Linq;

namespace ElectoralSystem.Core.Handlers
{
    public class CreatePollingStationMiddleDataHandler : IRequestHandler<CreatePollingStationMiddleData, PollingStation>
    {
        private readonly IPollingStationRepository _repository;
        private readonly ILogger _logger;

        public CreatePollingStationMiddleDataHandler(IPollingStationRepository repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<PollingStation> Handle(CreatePollingStationMiddleData request, CancellationToken cancellationToken)
        {
            var existing = (await _repository.GetAsync(x => x.Number == request.PollingStation.Number)).FirstOrDefault();

            if (existing is not null)
            {
                _logger.Log(Severity.WARNING, $"Attempt to create polling station with duplicated number '{request.PollingStation.Number}'.");
                throw new PollingStationNumberAlreadyExistsException(request.PollingStation.Number);
            }

            var response = await _repository.CreateAsync(request.PollingStation);

            return response;
        }
    }
}

