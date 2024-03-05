using Microsoft.EntityFrameworkCore;
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

    public async Task<IReadOnlyList<Note>> GetAllAsync(
        int pageNumber,
        int pageSize)
        => await _context
                    .Notes
                    .AsNoTracking()
                    .OrderByDescending(n=>n.LastModified)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();


    public async Task<int> GetTotalCountAsync()
        => await _context
                    .Notes
                    .AsNoTracking()
                    .CountAsync();

    public async Task<Option<Note>> GetByIdAsync(NoteId id)
    {
        var note = await _context
            .Notes
            .FindAsync(id);

        return note.SomeNotNull();
    }
}
