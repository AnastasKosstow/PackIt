using PackIt.Domain.Exceptions;
using System.Net;

namespace PackIt.Api.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await this.next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var statusCode = GetHttpStatusCode(exception);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;
        await context.Response.WriteAsync(exception.Message);
    }

    private HttpStatusCode GetHttpStatusCode(Exception exception)
    {
        switch (exception)
        {
            case EmptyPackingListNameException:
                return HttpStatusCode.BadRequest; 
            case LocalizationParameterException:
                return HttpStatusCode.BadRequest;

            default:
                return HttpStatusCode.InternalServerError;
        }
    }
}

public static class ExceptionHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}
