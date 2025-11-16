namespace ElectoralSystem.API.Repository.Entities
{
    public class ChangeHistory : EntityBase
    {
        public string TableName { get; set; } = string.Empty;

        public Guid UserId { get; set; }

        public Guid RecordId { get; set; }

        public string Action { get; set; } = string.Empty;

        public string OldValue { get; set; } = string.Empty;

        public string NewValue { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public User User { get; set; } 
    }
}