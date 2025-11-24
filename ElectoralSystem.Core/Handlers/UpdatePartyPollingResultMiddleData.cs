using ElectoralSystem.API.Repository.Entities;
using MediatR;

namespace ElectoralSystem.API.Core.Handlers
{
    public class UpdatePartyPollingResultMiddleData : IRequest<int>
    {
        public PartyPollingResult PartyPollingResult { get; set; }

        public UpdatePartyPollingResultMiddleData(PartyPollingResult partyPollingResult)
        {
            PartyPollingResult = partyPollingResult;
        }
    }
}

