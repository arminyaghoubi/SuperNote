using FluentResults;
using SuperNote.Application.Abstractions.Commands;
using SuperNote.Domain.Abstractions.DataAccess;
using SuperNote.Domain.Notes;

namespace SuperNote.Application.Notes.Commands.CreateNote;

public class CreateNoteCommandHandler : ICommandHandler<CreateNoteCommand, Result<Guid>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly INoteRepository _noteRepository;
    private readonly TimeProvider _timeProvider;

    public CreateNoteCommandHandler(
        IUnitOfWork unitOfWork,
        INoteRepository noteRepository,
        TimeProvider timeProvider)
    {
        _unitOfWork = unitOfWork;
        _noteRepository = noteRepository;
        _timeProvider = timeProvider;
    }

    public async Task<Result<Guid>> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        var noteText = NoteText.Create(request.Text);

        if (noteText.IsFailed)
        {
            return Result.Fail(noteText.Errors);
        }

        Note note = new(noteText.Value, _timeProvider.GetUtcNow().UtcDateTime);

        await _noteRepository.AddAsync(note);

        await _unitOfWork.SaveChangesAsync();

        return Result.Ok<Guid>(note.Id.Value);
    }
}