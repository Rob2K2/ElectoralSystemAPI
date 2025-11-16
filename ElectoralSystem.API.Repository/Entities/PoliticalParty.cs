namespace ElectoralSystem.API.Repository.Entities
{
    public class PoliticalParty : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string Acronym { get; set; } = string.Empty;
    }
}
