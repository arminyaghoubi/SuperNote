using Microsoft.EntityFrameworkCore;
using SuperNote.Domain.Notes;

namespace SuperNote.DataAccess.Contexts;

public class SuperNoteContext : DbContext
{
    public DbSet<Note> Notes { get; set; }

    public SuperNoteContext(DbContextOptions<SuperNoteContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SuperNoteContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
