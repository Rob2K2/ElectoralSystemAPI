using ElectoralSystem.API.Core.Interfaces;
using ElectoralSystem.API.Repository.Entities;
using MediatR;

namespace ElectoralSystem.API.Core.Handlers
{
    public class UpdatePartyPollingResultMiddleData : IRequest<int>, IAuditableCommand
    {
        public PartyPollingResult PartyPollingResult { get; set; }

        public UpdatePartyPollingResultMiddleData(PartyPollingResult partyPollingResult)
        {
            PartyPollingResult = partyPollingResult;
        }

        public Guid RecordId => PartyPollingResult.Id;

        public string AuditAction => "UPDATE_PARTY_POLLING_RESULT";

        public Type EntityType => typeof(PartyPollingResult);
    }
}

