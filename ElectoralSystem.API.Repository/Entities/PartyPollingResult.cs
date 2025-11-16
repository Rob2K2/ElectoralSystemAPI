namespace ElectoralSystem.API.Repository.Entities
{
    public class PartyPollingResult : EntityBase
    {
        public Guid PollStationId { get; set; }

        public Guid PoliticalPartyId { get; set; }

        public int VotesValid { get; set; }

        public int VotesBlank { get; set; }

        public int VotesNull { get; set; }

        public DateTime RegisteredDate { get; set; }

        public PollingStation PollingStation { get; set; }

        public PoliticalParty PoliticalParty { get; set; }

    }
}
