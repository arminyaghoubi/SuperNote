using SuperNote.Domain;
using SuperNote.Application;
using SuperNote.DataAccess;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string MyAllowSpecificOrigins = "Frontend";

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("https://localhost:5173")
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

builder.Services.AddFastEndpoints();
builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(Program).Assembly, typeof(ApplicationServices).Assembly));
builder.Services.SwaggerDocument(options =>
{
    options.ShortSchemaNames = true;
});
builder.Services.AddSingleton(TimeProvider.System);

builder.Services
    .AddDomainServices()
    .AddApplicationServices()
    .AddDataAccessServices(builder.Configuration.GetConnectionString("SuperNote"));

var app = builder.Build();
app.UseFastEndpoints(x => x.Errors.UseProblemDetails());
app.UseSwaggerGen();
app.UseCors(MyAllowSpecificOrigins);
app.Run();