using FluentValidation.Results;

namespace Watchdog.Backend.Application.Exceptions;

public class ValidationException : Exception
{
    public IEnumerable<string> Errors { get; }
    public ValidationException(ValidationResult validationResult)
    {
        Errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
    }
}