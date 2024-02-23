using Microsoft.EntityFrameworkCore;
using SuperNote.DataAccess.Contexts;
using SuperNote.Domain.Abstractions.Aggregates;
using SuperNote.Domain.Abstractions.DataAccess;

namespace SuperNote.DataAccess.Repositories;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : AggregateRoot
{
    private readonly SuperNoteContext _context;

    public Repository(SuperNoteContext context) => _context = context;

    public async Task<IReadOnlyList<TEntity>> GetEntitiesAsync() => await _context.Set<TEntity>().ToListAsync();
    public async Task AddAsync(TEntity entity) => await _context.Set<TEntity>().AddAsync(entity);
    public void UpdateAsync(TEntity entity) => _context.Set<TEntity>().Update(entity);
    public void DeleteAsync(TEntity entity) => _context.Set<TEntity>().Remove(entity);
}
