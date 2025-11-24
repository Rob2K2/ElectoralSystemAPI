using ElectoralSystem.API.Error.Bussiness;
using ElectoralSystem.API.Repository.Entities;
using ElectoralSystem.API.Repository.Interfaces;
using MediatR;
using System.Linq;

namespace ElectoralSystem.API.Core.Handlers
{
    public class DeletePartyPollingResultMiddleDataHandler : IRequestHandler<DeletePartyPollingResultMiddleData, int>
    {
        public readonly IPartyPollingResultRepository _repository;

        public DeletePartyPollingResultMiddleDataHandler(IPartyPollingResultRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(DeletePartyPollingResultMiddleData request, CancellationToken cancellationToken)
        {
            var response = (await _repository.GetAsync(x => x.Id == request._PartyPollingResult.Id)).FirstOrDefault();

            if (response is null)
            {
                throw new PartyPollingResultIdNotFoundException(request._PartyPollingResult.Id);
            }

            return await _repository.DeleteAsync(response);
        }
    }
}

