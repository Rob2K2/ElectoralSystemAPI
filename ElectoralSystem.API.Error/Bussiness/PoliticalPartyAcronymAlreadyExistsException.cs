namespace ElectoralSystem.API.Error.Bussiness
{
    public class PoliticalPartyAcronymAlreadyExistsException : BussinesException
    {
        public PoliticalPartyAcronymAlreadyExistsException(string acronym)
            : base($"The political party with acronym '{acronym}' already exists.")
        {
        }
    }
}

