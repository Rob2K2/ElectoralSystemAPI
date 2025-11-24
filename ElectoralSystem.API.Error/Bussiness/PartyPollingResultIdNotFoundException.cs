using System;

namespace ElectoralSystem.API.Error.Bussiness
{
    public class PartyPollingResultIdNotFoundException : BussinesException
    {
        public PartyPollingResultIdNotFoundException(Guid id) 
            : base($"The party polling result with id {id} does not exist.")
        {
        }
    }
}

