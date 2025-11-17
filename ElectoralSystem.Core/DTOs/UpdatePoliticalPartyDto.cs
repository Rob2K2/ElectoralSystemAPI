using System;

namespace ElectoralSystem.API.Core.DTOs
{
    public class UpdatePoliticalPartyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Acronym { get; set; } = string.Empty;
    }
}

