using System.Net;

namespace SchoolSystem.Domain.Result;

public class OperationResult<T>
{
    public T? Data { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; } = null!;

    public List<string>? Errors { get; set; } = null!;
    public HttpStatusCode StatusCode { get; set; }
    
    public static OperationResult<T> SuccessResult(T? data,
        HttpStatusCode statusCode,
        string message = "")
    {
        return new OperationResult<T>
        {
            Data = data,
            Success = true,
            Message = message,
            StatusCode = statusCode,
        };
    }
}