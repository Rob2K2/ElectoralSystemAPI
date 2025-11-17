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
    public class CreatePoliticalPartyMiddleDataHandler : IRequestHandler<CreatePoliticalPartyMiddleData, PoliticalParty>
    {
        private readonly IPoliticalPartyRepository _repository;
        private readonly ILogger _logger;

        public CreatePoliticalPartyMiddleDataHandler(IPoliticalPartyRepository repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<PoliticalParty> Handle(CreatePoliticalPartyMiddleData request, CancellationToken cancellationToken)
        {
            var existing = (await _repository.GetAsync(x => x.Acronym == request.PoliticalParty.Acronym)).FirstOrDefault();

            if (existing is not null)
            {
                _logger.Log(Severity.WARNING, $"Attempt to create political party with duplicated acronym '{request.PoliticalParty.Acronym}'.");
                throw new PoliticalPartyAcronymAlreadyExistsException(request.PoliticalParty.Acronym);
            }

            var response = await _repository.CreateAsync(request.PoliticalParty);

            return response;
        }
    }
}
