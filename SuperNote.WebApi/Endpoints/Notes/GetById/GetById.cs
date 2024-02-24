using FastEndpoints;
using MediatR;
using SuperNote.Application.Notes.Queries.GetNoteById;
using SuperNote.Domain.Notes;
using SuperNote.WebApi.Extensions;

namespace SuperNote.WebApi.Endpoints.Notes.GetById;

public class GetById(IMediator mediator) : Endpoint<GetNoteByIdRequest, NoteDto>
{
    public override void Configure()
    {
        AllowAnonymous();

        Get("/Notes/{id:guid}");

        Summary(s =>
        {
            s.Summary = "Get a note by Id.";
        });
    }

    public override async Task HandleAsync(GetNoteByIdRequest request, CancellationToken cancellationToken)
    {
        var note = await mediator.Send(new GetNoteByIdQuery(new NoteId(request.Id)), cancellationToken);

        if (note.IsSuccess)
        {
            await SendOkAsync(note.Value, cancellationToken);
        }
        else
        {
            await this.SendProblemDetailsResponse(note, cancellationToken);
        }
    }
}