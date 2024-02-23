using SuperNote.Domain.Abstractions.Aggregates;

namespace SuperNote.Domain.Abstractions.DataAccess;

public interface IRepository<TEntity>
    where TEntity : AggregateRoot
{
    Task<IReadOnlyList<TEntity>> GetEntitiesAsync();
    Task AddAsync(TEntity entity);
    void UpdateAsync(TEntity entity);
    void DeleteAsync(TEntity entity);
}