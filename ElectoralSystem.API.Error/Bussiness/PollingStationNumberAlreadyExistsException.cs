namespace ElectoralSystem.API.Error.Bussiness
{
    public class PollingStationNumberAlreadyExistsException : BussinesException
    {
        public PollingStationNumberAlreadyExistsException(string number)
            : base($"The polling station with number '{number}' already exists.")
        {
        }
    }
}

