using System;

namespace ElectoralSystem.API.Core.DTOs
{
    public class UpdatePollingStationDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public int RegisteredVoters { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}

