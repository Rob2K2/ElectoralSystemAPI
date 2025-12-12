namespace ElectoralSystem.API.Core.Interfaces
{
    public interface IAuditableCommand
    {
        public Guid RecordId { get; }

        public string AuditAction { get; }

        public Type EntityType {get; }
    }
}
