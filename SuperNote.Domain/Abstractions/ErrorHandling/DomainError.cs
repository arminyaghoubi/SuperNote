namespace SuperNote.Domain.Abstractions.ErrorHandling;
using FluentResults;

public class DomainError : Error
{
    public const string ErrorCodeLiteral = "ErrorCode";

    public DomainError(string message, string code)
        : base(message)
    {
        WithMetadata(ErrorCodeLiteral, code);
    }
}
