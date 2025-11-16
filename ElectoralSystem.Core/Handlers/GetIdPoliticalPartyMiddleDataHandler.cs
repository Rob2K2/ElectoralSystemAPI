using ElectoralSystem.API.Error.Bussiness;
using ElectoralSystem.API.Repository.Entities;
using ElectoralSystem.API.Repository.Interfaces;
using MediatR;

namespace ElectoralSystem.API.Core.Handlers
{
    public class GetIdPoliticalPartyMiddleDataHandler : IRequestHandler<GetIdPoliticalPartyMiddleData, PoliticalParty>
    {
        private readonly IPoliticalPartyRepository _repository;

        public GetIdPoliticalPartyMiddleDataHandler(IPoliticalPartyRepository repository)
        {
            _repository = repository;
        }
        public async Task<PoliticalParty?> Handle(GetIdPoliticalPartyMiddleData request, CancellationToken cancellationToken)
        {
            var response = (await _repository.GetAsync(x => x.Id.Equals(request.PoliticalPartyId))).FirstOrDefault();

            if (response is null)
            {
                throw new PoliticalPartyIdNotFoundException(request.PoliticalPartyId);
            }
            return response;
        }
    }
}
