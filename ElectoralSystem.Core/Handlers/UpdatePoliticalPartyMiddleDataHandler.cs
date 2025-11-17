using ElectoralSystem.API.Core.Handlers;
using ElectoralSystem.API.Error;
using ElectoralSystem.API.Error.Bussiness;
using ElectoralSystem.API.Error.Logs;
using ElectoralSystem.API.Repository.Interfaces;
using MediatR;
using System.Linq;

namespace ElectoralSystem.Core.Handlers
{
    public class UpdatePoliticalPartyMiddleDataHandler : IRequestHandler<UpdatePoliticalPartyMiddleData, int>
    {
        private readonly IPoliticalPartyRepository _repository;
        private readonly ILogger _logger;

        public UpdatePoliticalPartyMiddleDataHandler(IPoliticalPartyRepository repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<int> Handle(UpdatePoliticalPartyMiddleData request, CancellationToken cancellationToken)
        {
            var existingParty = (await _repository.GetAsync(x => x.Id == request.PoliticalParty.Id)).FirstOrDefault();

            if (existingParty is null)
            {
                throw new PoliticalPartyIdNotFoundException(request.PoliticalParty.Id);
            }

            var duplicatedAcronym = (await _repository
                .GetAsync(x => x.Acronym == request.PoliticalParty.Acronym && x.Id != request.PoliticalParty.Id))
                .FirstOrDefault();

            if (duplicatedAcronym is not null)
            {
                _logger.Log(Severity.WARNING, $"Attempt to update political party to duplicated acronym '{request.PoliticalParty.Acronym}'.");
                throw new PoliticalPartyAcronymAlreadyExistsException(request.PoliticalParty.Acronym);
            }

            return await _repository.UpdateAsync(request.PoliticalParty);
        }
    }
}

