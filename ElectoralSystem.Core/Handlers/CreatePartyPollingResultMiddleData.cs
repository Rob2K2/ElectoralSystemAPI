using ElectoralSystem.API.Core.Interfaces;
using ElectoralSystem.API.Repository.Entities;
using MediatR;

namespace ElectoralSystem.API.Core.Handlers
{
    public class CreatePartyPollingResultMiddleData : IRequest<PartyPollingResult>, IAuditableCommand
    {
        public PartyPollingResult PartyPollingResult { get; set; }

        public CreatePartyPollingResultMiddleData(PartyPollingResult partyPollingResult)
        {
            PartyPollingResult = partyPollingResult;
        }

        public Guid RecordId => PartyPollingResult.Id;

        public string AuditAction => "CREATE_PARTY_POLLING_RESULT";

        public Type EntityType => typeof(PartyPollingResult);
    }
}

