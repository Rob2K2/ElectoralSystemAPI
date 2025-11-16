using ElectoralSystem.API.Repository.Entities;
using ElectoralSystem.API.Repository.Interfaces;
using MediatR;

namespace ElectoralSystem.API.Core.Handlers
{
    public class GetAllPoliticalPartyMiddleDataHandler : IRequestHandler<GetAllPoliticalPartyMiddleData, IEnumerable<PoliticalParty>>
    {
        private readonly IPoliticalPartyRepository _repository;

        public GetAllPoliticalPartyMiddleDataHandler(IPoliticalPartyRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PoliticalParty>> Handle(GetAllPoliticalPartyMiddleData request, CancellationToken cancellationToken)
        {
            var response = await _repository.GetAsync(x => true);

            return response.ToList();
        }
    }
}
