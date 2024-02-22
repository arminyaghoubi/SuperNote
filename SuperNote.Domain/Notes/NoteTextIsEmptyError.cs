using SuperNote.Domain.Abstractions.ErrorHandling;

namespace SuperNote.Domain.Notes;

public class NoteTextIsEmptyError : DomainError
{
    public NoteTextIsEmptyError(string message, string code)
        : base(message, code)
    {
        WithMetadata(nameof(ErrorTypes), ErrorTypes.InvalidData);
    }
}
