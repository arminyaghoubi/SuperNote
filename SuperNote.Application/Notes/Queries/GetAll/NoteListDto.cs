using SuperNote.Application.Notes.Queries.GetNoteById;

public record NoteListDto(int TotalCount, IReadOnlyList<NoteDto> Notes);
