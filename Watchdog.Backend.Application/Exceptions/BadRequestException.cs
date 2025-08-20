namespace Watchdog.Backend.Application.Exceptions;

public class BadRequestException(string message) : Exception(message);