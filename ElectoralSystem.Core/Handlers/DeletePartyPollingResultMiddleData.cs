using ElectoralSystem.API.Core.Interfaces;
using ElectoralSystem.API.Repository.Entities;
using MediatR;

namespace ElectoralSystem.API.Core.Handlers
{
    public class DeletePartyPollingResultMiddleData : IRequest<int>, IAuditableCommand
    {
        public PartyPollingResult PartyPollingResult { get; }

        public DeletePartyPollingResultMiddleData(PartyPollingResult partyPollingResult)
        {
            PartyPollingResult = partyPollingResult;
        }

        public Guid RecordId => PartyPollingResult.Id;

        public string AuditAction => "DELETE_PARTY_POLLING_RESULT";

        public Type EntityType => typeof(PartyPollingResult);
    }
}

