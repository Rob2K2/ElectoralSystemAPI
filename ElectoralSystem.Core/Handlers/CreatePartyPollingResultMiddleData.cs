using ElectoralSystem.API.Repository.Entities;
using MediatR;

namespace ElectoralSystem.API.Core.Handlers
{
    public class CreatePartyPollingResultMiddleData : IRequest<PartyPollingResult>
    {
        public PartyPollingResult PartyPollingResult { get; set; }

        public CreatePartyPollingResultMiddleData(PartyPollingResult partyPollingResult)
        {
            PartyPollingResult = partyPollingResult;
        }
    }
}

