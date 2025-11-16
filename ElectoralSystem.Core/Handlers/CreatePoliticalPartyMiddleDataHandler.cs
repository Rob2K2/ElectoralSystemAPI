using ElectoralSystem.API.Core.Handlers;
using ElectoralSystem.API.Repository.Entities;
using ElectoralSystem.API.Repository.Interfaces;
using MediatR;

namespace ElectoralSystem.Core.Handlers
{
    public class CreatePoliticalPartyMiddleDataHandler : IRequestHandler<CreatePoliticalPartyMiddleData, PoliticalParty>
    {
        private readonly IPoliticalPartyRepository _repository;

        public CreatePoliticalPartyMiddleDataHandler(IPoliticalPartyRepository repository)
        {
            _repository = repository;
        }
        public async Task<PoliticalParty> Handle(CreatePoliticalPartyMiddleData request, CancellationToken cancellationToken)
        {
            var response = await _repository.CreateAsync(request.PoliticalParty);

            return response;
        }
    }
}
