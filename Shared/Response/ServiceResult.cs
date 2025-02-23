using System.Net;
using System.Text.Json.Serialization;

namespace Shared.Response;

public class ServiceResult
{
    public string? Message { get; set; }
    public HttpStatusCode Status { get; set; }

    public static ServiceResult Success(string message, HttpStatusCode status = HttpStatusCode.OK)
    {
        return new ServiceResult()
        {
            Message = message,
            Status = status
        };
    }

}

public class ServiceResult<T> : ServiceResult
{
    public T? Data { get; set; }

    public static ServiceResult<T> Success(T data,string message ,HttpStatusCode status = HttpStatusCode.OK)
    {
        return new ServiceResult<T>()
        {
            Data = data,
            Message = message,
            Status = status
        };
    }
}
