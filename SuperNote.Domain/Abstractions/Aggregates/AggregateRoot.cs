using SuperNote.Domain.Abstractions.DomainEvents;

namespace SuperNote.Domain.Abstractions.Aggregates;

public abstract class AggregateRoot
{
    private readonly List<IDomainEvent> _events = new();

    public IReadOnlyList<IDomainEvent> Events => _events;

    protected void AddEvent(IDomainEvent domainEvent) => _events.Add(domainEvent);

    public void ClearEvents() => _events.Clear();
}
