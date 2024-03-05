using FluentResults;
using SuperNote.Application.Abstractions.Queries;

public record GetAllNoteQuery(int PageNumber, int PageSize) : IQuery<Result<NoteListDto>>;
