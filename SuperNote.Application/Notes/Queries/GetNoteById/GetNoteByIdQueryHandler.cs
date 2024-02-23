using FluentResults;
using Optional;
using Optional.Unsafe;
using SuperNote.Application.Abstractions.Queries;
using SuperNote.Domain.Notes;

namespace SuperNote.Application.Notes.Queries.GetNoteById;

public class GetNoteByIdQueryHandler : IQueryHandler<GetNoteByIdQuery, Result<NoteDto>>
{
    private readonly INoteRepository _noteRepository;

    public GetNoteByIdQueryHandler(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    public async Task<Result<NoteDto>> Handle(GetNoteByIdQuery request, CancellationToken cancellationToken)
    {
        Option<Note> noteOption = await _noteRepository.GetByIdAsync(request.Id);

        if (!noteOption.HasValue)
        {
            return NoteErrors.NoteNotFound;
        }

        var note = noteOption.ValueOrDefault();

        NoteDto noteDto = new(
            note.Id.Value,
            note.Text.Value,
            note.LastModified);

        return Result.Ok(noteDto);
    }
}
