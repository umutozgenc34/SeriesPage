using System.Net;
using System.Text.Json.Serialization;

namespace Shared.Response;

public class ServiceResult
{
    public string? Message { get; set; }
    [JsonIgnore]
    public HttpStatusCode Status { get; set; }
    [JsonIgnore]
    public bool Succes { get; set; }

    public static ServiceResult Success(string message, HttpStatusCode status = HttpStatusCode.OK)
    {
        return new ServiceResult()
        {
            Message = message,
            Status = status,
            Succes= true
        };
    }

}

public class ServiceResult<T> : ServiceResult
{
    public T? Data { get; set; }
    [JsonIgnore] public string? UrlAsCreated { get; set; }
    public static ServiceResult<T> Success(T data,string message ,HttpStatusCode status = HttpStatusCode.OK)
    {
        return new ServiceResult<T>()
        {
            Data = data,
            Message = message,
            Status = status,
            Succes = true
        };
    }

    public static ServiceResult<T> SuccessAsCreated(T data, string message,string urlAsCreated)
    {
        return new ServiceResult<T>()
        {
            Data = data,
            Message = message,
            Status = HttpStatusCode.Created,
            UrlAsCreated = urlAsCreated,
            Succes = true
        };
    }
}
