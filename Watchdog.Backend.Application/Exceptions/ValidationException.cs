using FluentValidation.Results;

namespace Watchdog.Backend.Application.Exceptions;

public class ValidationException : Exception
{
    public ValidationException(ValidationResult validationResult)
    {
        var validationErrors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
        
    }
}