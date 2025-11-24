using ElectoralSystem.API.Repository.Entities;
using ElectoralSystem.API.Repository.Interfaces;
using MediatR;
using System.Linq;

namespace ElectoralSystem.API.Core.Handlers
{
    public class GetAllPartyPollingResultMiddleDataHandler : IRequestHandler<GetAllPartyPollingResultMiddleData, IEnumerable<PartyPollingResult>>
    {
        private readonly IPartyPollingResultRepository _repository;

        public GetAllPartyPollingResultMiddleDataHandler(IPartyPollingResultRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PartyPollingResult>> Handle(GetAllPartyPollingResultMiddleData request, CancellationToken cancellationToken)
        {
            var response = await _repository.GetAsync(x => true);
            return response.ToList();
        }
    }
}

