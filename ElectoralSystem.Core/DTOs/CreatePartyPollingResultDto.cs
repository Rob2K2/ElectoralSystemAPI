using System;

namespace ElectoralSystem.API.Core.DTOs
{
    public class CreatePartyPollingResultDto
    {
        public Guid PollStationId { get; set; }
        public Guid PoliticalPartyId { get; set; }
        public int VotesValid { get; set; }
        public int VotesBlank { get; set; }
        public int VotesNull { get; set; }
        public DateTime RegisteredDate { get; set; }
    }
}

