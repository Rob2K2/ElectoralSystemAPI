using System;

namespace ElectoralSystem.API.Error.Bussiness
{
    public class PartyPollingResultDuplicateException : BussinesException
    {
        public PartyPollingResultDuplicateException(Guid pollStationId, Guid politicalPartyId, DateTime registeredDate)
            : base($"A result already exists for party '{politicalPartyId}' in station '{pollStationId}' on date '{registeredDate:yyyy-MM-dd}'.")
        {
        }
    }
}

