using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SuperNote.DataAccess.Contexts;
using SuperNote.DataAccess.Repositories;
using SuperNote.DataAccess.UnitOfWorks;
using SuperNote.Domain.Abstractions.DataAccess;
using SuperNote.Domain.Notes;

namespace SuperNote.DataAccess;

public static class DataAccessServices
{
    private const string DatabaseName = "SuperNoteInMemoryDatabase";

    public static IServiceCollection AddDataAccessServices(
        this IServiceCollection services,
        string? connectionString = null)
    {
        if (connectionString is null)
        {
            services.AddDbContext<SuperNoteContext>(options => options.UseInMemoryDatabase(DatabaseName));
        }
        else
        {
            services.AddDbContext<SuperNoteContext>(options => options.UseNpgsql(connectionString));
        }

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<INoteRepository, NoteRepository>();

        return services;
    }
}
