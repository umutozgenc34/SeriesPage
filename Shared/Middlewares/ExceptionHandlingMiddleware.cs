using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Shared.Exceptions;
using Shared.Response;

namespace Shared.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        var status = exception switch
        {
            NotFoundException => HttpStatusCode.NotFound,
            BusinessException => HttpStatusCode.BadRequest,
            _ => HttpStatusCode.InternalServerError
        };

        var message = exception.Message;

        if (status == HttpStatusCode.InternalServerError)
        {
            logger.LogError(exception, "Unhandled exception while processing {Method} {Path}", httpContext.Request.Method, httpContext.Request.Path);
            message = "An unexpected error occurred.";
        }

        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = (int)status;

        var result = ServiceResult.Fail(message, status);

        return httpContext.Response.WriteAsync(JsonSerializer.Serialize(result, JsonOptions));
    }
}
