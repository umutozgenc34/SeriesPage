using Shared.Exceptions;
using Shared.Response;
using System.Net.Http;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Shared.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {

        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = exception switch
        {
            NotFoundException => (int)HttpStatusCode.NotFound,
            BusinessException => (int)HttpStatusCode.BadRequest,
            _ => (int)HttpStatusCode.InternalServerError
        };

        var result = new ServiceResult
        {
            Succes = false,
            Message = exception.Message,
            Status = (HttpStatusCode)httpContext.Response.StatusCode
        };

        var jsonResponse = JsonSerializer.Serialize(result);
        return httpContext.Response.WriteAsync(jsonResponse);
    }
}