namespace ElectoralSystem.API.Error.Bussiness
{
    public class PoliticalPartyIdNotFoundException : BussinesException
    {
        public PoliticalPartyIdNotFoundException(Guid id) 
            : base($"The political party with id {id} does not exist.")
        {
        }
    }
}
