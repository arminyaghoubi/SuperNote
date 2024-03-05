using SuperNote.Domain.Abstractions.Aggregates;

namespace SuperNote.Domain.Notes;

public class Note : AggregateRoot
{
    public NoteId Id { get; }
    public NoteText Text { get; }
    public DateTime LastModified { get; private set; }

    /// <summary>
    /// Required by Entity Framework
    /// </summary>
    private Note()
    {
    }

    public Note(NoteText text, DateTime lastModified)
    {
        Id = NoteId.New();
        Text = text;
        LastModified = lastModified;

        RaiseDomainEvent(new NoteCreatedDomainEvent(Id));
    }
}
