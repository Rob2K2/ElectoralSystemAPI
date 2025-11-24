using ElectoralSystem.API.Repository.Entities;
using MediatR;

namespace ElectoralSystem.API.Core.Handlers
{
    public class DeletePartyPollingResultMiddleData : IRequest<int>
    {
        public PartyPollingResult _PartyPollingResult { get; }

        public DeletePartyPollingResultMiddleData(PartyPollingResult partyPollingResult)
        {
            _PartyPollingResult = partyPollingResult;
        }
    }
}

