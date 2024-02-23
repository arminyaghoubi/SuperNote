using Optional;
using SuperNote.Domain.Abstractions.DataAccess;

namespace SuperNote.Domain.Notes;

public interface INoteRepository : IRepository<Note>
{
    Task<Option<Note>> GetByIdAsync(NoteId id);
}
