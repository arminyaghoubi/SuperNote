using FluentResults;
using SuperNote.Application.Abstractions.Queries;
using SuperNote.Application.Notes.Queries.GetNoteById;
using SuperNote.Domain.Notes;

public class GetAllNoteQueryHandler : IQueryHandler<GetAllNoteQuery, Result<NoteListDto>>
{
    private readonly INoteRepository _noteRepository;

    public GetAllNoteQueryHandler(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    public async Task<Result<NoteListDto>> Handle(GetAllNoteQuery request, CancellationToken cancellationToken)
    {
        var totalCount = await _noteRepository.GetTotalCountAsync();
        var notes = await _noteRepository.GetAllAsync(request.PageNumber, request.PageSize);

        NoteListDto noteListDto = new(
            totalCount,
            notes.Select(note =>
                    new NoteDto(
                        note.Id.Value,
                        note.Text.Value.Length > 100 ? $"{note.Text.Value.Substring(0, 100)}..." : note.Text.Value,
                        note.LastModified))
            .ToList());

        return Result.Ok(noteListDto);
    }
}