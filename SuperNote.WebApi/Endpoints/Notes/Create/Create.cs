using FastEndpoints;
using MediatR;
using SuperNote.Application.Notes.Commands.CreateNote;
using SuperNote.WebApi.Extensions;

namespace SuperNote.WebApi.Endpoints.Notes.Create;

public class Create(IMediator mediator) : Endpoint<CreateNoteRequest, CreateNoteResponse>
{
    public override void Configure()
    {
        AllowAnonymous();

        Post("/Notes/");

        Summary(s =>
        {
            s.Summary = "Create a new note.";
        });
    }

    public override async Task HandleAsync(CreateNoteRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateNoteCommand(request.Text), cancellationToken);

        if (result.IsSuccess)
        {
            await SendOkAsync(new CreateNoteResponse(result.Value), cancellationToken);
        }
        else
        {
            await this.SendProblemDetailsResponse(result, cancellationToken);
        }
    }
}