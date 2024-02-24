using FastEndpoints;
using FluentResults;
using FluentValidation.Results;
using SuperNote.Domain.Abstractions.ErrorHandling;

namespace SuperNote.WebApi.Extensions;

public static class ResponseExtensions
{
    public static async Task SendProblemDetailsResponse<T>(
        this IEndpoint endpoint,
        Result<T> result,
        CancellationToken cancellationToken)
    {
        if (result.IsSuccess)
        {
            throw new ArgumentException("The Result<T> object must be in a failed state.");
        }

        var errorType = GetErrorType(result.Errors.First());

        var statusCode = errorType switch
        {
            ErrorTypes.NotFound => StatusCodes.Status404NotFound,
            ErrorTypes.InvalidData => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };

        var failures = ToFailures(result.Errors);

        await endpoint.HttpContext.Response.SendErrorsAsync(
            failures,
            statusCode,
            cancellation: cancellationToken);

        static ErrorTypes GetErrorType(IError error)
            => (ErrorTypes)error.Metadata[nameof(ErrorTypes)];

        static List<ValidationFailure> ToFailures(List<IError> errors)
            => errors.Select(e =>
            {
                var errorCode = e.Metadata[DomainError.ErrorCodeLiteral];
                return new ValidationFailure(errorCode.ToString(), e.Message);
            }).ToList();
    }
}
