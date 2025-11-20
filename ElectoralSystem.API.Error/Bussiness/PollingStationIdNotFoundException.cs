using System;

namespace ElectoralSystem.API.Error.Bussiness
{
    public class PollingStationIdNotFoundException : BussinesException
    {
        public PollingStationIdNotFoundException(Guid id) 
            : base($"The polling station with id {id} does not exist.")
        {
        }
    }
}

