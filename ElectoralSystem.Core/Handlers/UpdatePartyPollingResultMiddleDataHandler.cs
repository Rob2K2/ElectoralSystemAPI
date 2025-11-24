using ElectoralSystem.API.Core.Handlers;
using ElectoralSystem.API.Error;
using ElectoralSystem.API.Error.Bussiness;
using ElectoralSystem.API.Error.Logs;
using ElectoralSystem.API.Repository.Interfaces;
using MediatR;
using System.Linq;

namespace ElectoralSystem.Core.Handlers
{
    public class UpdatePartyPollingResultMiddleDataHandler : IRequestHandler<UpdatePartyPollingResultMiddleData, int>
    {
        private readonly IPartyPollingResultRepository _repository;
        private readonly IPollingStationRepository _pollingStationRepository;
        private readonly IPoliticalPartyRepository _politicalPartyRepository;
        private readonly ILogger _logger;

        public UpdatePartyPollingResultMiddleDataHandler(
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

        public async Task<int> Handle(UpdatePartyPollingResultMiddleData request, CancellationToken cancellationToken)
        {
            // Validar que el resultado existe
            var existing = (await _repository.GetAsync(x => x.Id == request.PartyPollingResult.Id)).FirstOrDefault();
            if (existing is null)
            {
                throw new PartyPollingResultIdNotFoundException(request.PartyPollingResult.Id);
            }

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

            // Validar que no exista otro resultado duplicado (excluyendo el actual)
            var duplicated = (await _repository.GetAsync(x => 
                x.PollStationId == request.PartyPollingResult.PollStationId &&
                x.PoliticalPartyId == request.PartyPollingResult.PoliticalPartyId &&
                x.RegisteredDate.Date == request.PartyPollingResult.RegisteredDate.Date &&
                x.Id != request.PartyPollingResult.Id
            )).FirstOrDefault();

            if (duplicated is not null)
            {
                _logger.Log(Severity.WARNING, 
                    $"Attempt to update result to duplicate for party {request.PartyPollingResult.PoliticalPartyId} " +
                    $"in station {request.PartyPollingResult.PollStationId} on {request.PartyPollingResult.RegisteredDate:yyyy-MM-dd}");
                
                throw new PartyPollingResultDuplicateException(
                    request.PartyPollingResult.PollStationId,
                    request.PartyPollingResult.PoliticalPartyId,
                    request.PartyPollingResult.RegisteredDate);
            }

            return await _repository.UpdateAsync(request.PartyPollingResult);
        }
    }
}

