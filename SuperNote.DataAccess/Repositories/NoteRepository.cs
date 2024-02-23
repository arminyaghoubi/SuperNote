using Optional;
using SuperNote.DataAccess.Contexts;
using SuperNote.Domain.Notes;

namespace SuperNote.DataAccess.Repositories;

public class NoteRepository : Repository<Note>, INoteRepository
{
    public NoteRepository(SuperNoteContext context)
        : base(context)
    {
    }

    public async Task<Option<Note>> GetByIdAsync(NoteId id)
    {
        var note = await _context
            .Notes
            .FindAsync(id);

        return note.SomeNotNull();
    }
}
