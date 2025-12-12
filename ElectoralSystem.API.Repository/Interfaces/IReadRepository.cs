namespace ElectoralSystem.API.Repository.Interfaces
{
    public interface IReadRepository
    {
        Task<object?> GetByIdAsync(Type entityType, Guid id);
    }
}
