using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperNote.Domain.Notes;

namespace SuperNote.DataAccess.Configurations;

public class NoteEntityTypeConfiguration : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder.HasKey(n => n.Id);

        builder
            .Property(n => n.Id)
            .HasConversion(id => id.Value, value => new NoteId(value));

        builder
            .Property(n => n.Text)
            .HasConversion(text => text.Value, value => NoteText.Create(value).Value);
    }
}
