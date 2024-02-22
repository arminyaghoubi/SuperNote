using FluentResults;

namespace SuperNote.Domain.Notes;

public sealed record NoteText
{
    public string? Value { get; }

    private NoteText(string value)
    {
        Value = value;
    }

    public static Result<NoteText> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return NoteErrors.NoteTextIsEmpty;
        }

        return Result.Ok(new NoteText(value));
    }
}
