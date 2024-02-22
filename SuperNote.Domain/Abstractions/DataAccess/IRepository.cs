using SuperNote.Domain.Abstractions.Aggregates;

namespace SuperNote.Domain.Abstractions.DataAccess;

public interface IRepository<TEntity>
    where TEntity : AggregateRoot
{
    Task<IReadOnlyList<TEntity>> GetEntitiesAsync();
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
}