using System.Net;

namespace Watchdog.Backend.Application.Responses;

public class BaseResponse
{
    public bool Success { get; set; } = true;
    public string Message { get; set; } = string.Empty;
    public List<string>? ValidationErrors { get; set; }
}