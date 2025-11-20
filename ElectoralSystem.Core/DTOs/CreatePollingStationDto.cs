namespace ElectoralSystem.API.Core.DTOs
{
    public class CreatePollingStationDto
    {
        public string Number { get; set; } = string.Empty;
        public int RegisteredVoters { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}

