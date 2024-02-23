using MediatR;
using SuperNote.DataAccess.Contexts;
using SuperNote.Domain.Abstractions.Aggregates;
using SuperNote.Domain.Abstractions.DataAccess;
using SuperNote.Domain.Abstractions.DomainEvents;

namespace SuperNote.DataAccess.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly IPublisher _publisher;
    private readonly SuperNoteContext _context;

    public UnitOfWork(
        SuperNoteContext context,
        IPublisher publisher)
    {
        _context = context;
        _publisher = publisher;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entities = GetDomainEntities(_context);
        var events = GetDomainEvents(entities);

        // Saves the changes to the database
        await _context.SaveChangesAsync(cancellationToken);

        // Executes domain event handlers
        foreach (var @event in events)
        {
            await _publisher.Publish(@event, cancellationToken);
        }

        entities.ForEach(e => e.ClearEvents());

        List<AggregateRoot> GetDomainEntities(SuperNoteContext context) =>
            context
                .ChangeTracker
                .Entries<AggregateRoot>()
                .Select(e => e.Entity)
                .ToList();

        List<IDomainEvent> GetDomainEvents(List<AggregateRoot> entities) =>
            entities
                .Where(e => e.Events.Any())
                .SelectMany(e => e.Events)
                .ToList();
    }
}
