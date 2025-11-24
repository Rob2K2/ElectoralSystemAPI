using ElectoralSystem.API.Repository.Entities;
using MediatR;
using System;

namespace ElectoralSystem.API.Core.Handlers
{
    public class GetIdPartyPollingResultMiddleData : IRequest<PartyPollingResult>
    {
        public Guid PartyPollingResultId { get; }

        public GetIdPartyPollingResultMiddleData(Guid partyPollingResultId)
        {
            PartyPollingResultId = partyPollingResultId;
        }
    }
}

