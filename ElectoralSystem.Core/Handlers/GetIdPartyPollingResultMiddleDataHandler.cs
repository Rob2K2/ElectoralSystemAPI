using ElectoralSystem.API.Error.Bussiness;
using ElectoralSystem.API.Repository.Entities;
using ElectoralSystem.API.Repository.Interfaces;
using MediatR;
using System.Linq;

namespace ElectoralSystem.API.Core.Handlers
{
    public class GetIdPartyPollingResultMiddleDataHandler : IRequestHandler<GetIdPartyPollingResultMiddleData, PartyPollingResult>
    {
        private readonly IPartyPollingResultRepository _repository;

        public GetIdPartyPollingResultMiddleDataHandler(IPartyPollingResultRepository repository)
        {
            _repository = repository;
        }

        public async Task<PartyPollingResult?> Handle(GetIdPartyPollingResultMiddleData request, CancellationToken cancellationToken)
        {
            var response = (await _repository.GetAsync(x => x.Id.Equals(request.PartyPollingResultId))).FirstOrDefault();

            if (response is null)
            {
                throw new PartyPollingResultIdNotFoundException(request.PartyPollingResultId);
            }
            return response;
        }
    }
}

