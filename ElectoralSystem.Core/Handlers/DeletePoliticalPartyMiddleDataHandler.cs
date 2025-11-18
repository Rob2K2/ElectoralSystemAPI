using ElectoralSystem.API.Error.Bussiness;
using ElectoralSystem.API.Repository.Entities;
using ElectoralSystem.API.Repository.Interfaces;
using MediatR;
using System.Linq;

namespace ElectoralSystem.API.Core.Handlers
{
    public class DeletePoliticalPartyMiddleDataHandler : IRequestHandler<DeletePoliticalPartyMiddleData, int>
    {
        public readonly IPoliticalPartyRepository _repository;

        public DeletePoliticalPartyMiddleDataHandler(IPoliticalPartyRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(DeletePoliticalPartyMiddleData request, CancellationToken cancellationToken)
        {
            var response = (await _repository.GetAsync(x => x.Id == request._PoliticalParty.Id)).FirstOrDefault();

            if (response is null)
            {
                throw new PoliticalPartyIdNotFoundException(request._PoliticalParty.Id);
            }

            return await _repository.DeleteAsync(response);
        }
    }
}