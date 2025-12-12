using ElectoralSystem.API.Core.Handlers;
using ElectoralSystem.API.Core.Interfaces;
using ElectoralSystem.API.Error;
using ElectoralSystem.API.Error.Bussiness;
using ElectoralSystem.API.Error.Logs;
using ElectoralSystem.API.Repository.Entities;
using ElectoralSystem.API.Repository.Interfaces;
using MediatR;

namespace ElectoralSystem.Core.Handlers
{
    public class CreatePartyPollingResultMiddleDataHandler : IRequestHandler<CreatePartyPollingResultMiddleData, PartyPollingResult>
    {
        private readonly IPartyPollingResultRepository _repository;
        private readonly IPollingStationRepository _pollingStationRepository;
        private readonly IPoliticalPartyRepository _politicalPartyRepository;
        private readonly ILogger _logger;

        public CreatePartyPollingResultMiddleDataHandler(
            IPartyPollingResultRepository repository,
            IPollingStationRepository pollingStationRepository,
            IPoliticalPartyRepository politicalPartyRepository,
            ILogger logger)
        {
            _repository = repository;
            _pollingStationRepository = pollingStationRepository;
            _politicalPartyRepository = politicalPartyRepository;
            _logger = logger;
        }

        public async Task<PartyPollingResult> Handle(CreatePartyPollingResultMiddleData request, CancellationToken cancellationToken)
        {
            // Validar que la mesa existe
            var station = (await _pollingStationRepository.GetAsync(x => x.Id == request.PartyPollingResult.PollStationId)).FirstOrDefault();
            if (station is null)
            {
                throw new PollingStationIdNotFoundException(request.PartyPollingResult.PollStationId);
            }

            // Validar que el partido existe
            var party = (await _politicalPartyRepository.GetAsync(x => x.Id == request.PartyPollingResult.PoliticalPartyId)).FirstOrDefault();
            if (party is null)
            {
                throw new PoliticalPartyIdNotFoundException(request.PartyPollingResult.PoliticalPartyId);
            }

            // Validar que no exista un resultado duplicado (misma mesa + mismo partido + misma fecha)
            var existing = (await _repository.GetAsync(x => 
                x.PollStationId == request.PartyPollingResult.PollStationId &&
                x.PoliticalPartyId == request.PartyPollingResult.PoliticalPartyId &&
                x.RegisteredDate.Date == request.PartyPollingResult.RegisteredDate.Date
            )).FirstOrDefault();

            if (existing is not null)
            {
                _logger.Log(Severity.WARNING, 
                    $"Attempt to create duplicate result for party {request.PartyPollingResult.PoliticalPartyId} " +
                    $"in station {request.PartyPollingResult.PollStationId} on {request.PartyPollingResult.RegisteredDate:yyyy-MM-dd}");
                
                throw new PartyPollingResultDuplicateException(
                    request.PartyPollingResult.PollStationId,
                    request.PartyPollingResult.PoliticalPartyId,
                    request.PartyPollingResult.RegisteredDate);
            }

            var response = await _repository.CreateAsync(request.PartyPollingResult);
            return response;
        }
    }
}

