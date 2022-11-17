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
            case InvalidTemperatureException or
                 EmptyPackingListNameException or
                 PackingItemParameterException or
                 LocalizationParameterException or
                 PackingItemAlreadyExistsException:
                return HttpStatusCode.BadRequest;

            default:
                return HttpStatusCode.InternalServerError;
        }
    }
}

public static class ExceptionHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}
