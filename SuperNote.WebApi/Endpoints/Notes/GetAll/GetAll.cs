using FastEndpoints;
using MediatR;

namespace SuperNote.WebApi.Endpoints.Notes.GetAll;

public class GetAll(IMediator mediator) : Endpoint<GetAllNoteRequest, NoteListDto>
{
    public override void Configure()
    {
        AllowAnonymous();

        Get("/Notes");

        Summary(s =>
        {
            s.Summary = "Get all notes by searching and pagination";
        });
    }

    public override async Task HandleAsync(GetAllNoteRequest request, CancellationToken cancellationToken)
    {
        var notes = await mediator.Send(new GetAllNoteQuery(request.PageNumber, request.PageSize), cancellationToken);

        await SendOkAsync(notes.Value, cancellationToken);
    }
}