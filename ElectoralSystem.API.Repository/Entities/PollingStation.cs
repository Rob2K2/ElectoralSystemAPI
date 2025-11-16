namespace ElectoralSystem.API.Repository.Entities
{
    public class PollingStation : EntityBase
    {
        public string Number { get; set; } = string.Empty;

        public int RegisteredVoters { get; set; }

        public string Status { get; set; } = string.Empty ;
    }
}