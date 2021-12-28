using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shamyr.AspNetCore.Factories;
using Shamyr.AspNetCore.HttpErrors;

namespace Shamyr.AspNetCore.ExceptionHandling;

public class ExceptionHandlingMiddleware: IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            var handlerFactory = context.RequestServices.GetRequiredService<IExceptionHandlerFactory>();
            var logger = context.RequestServices.GetRequiredService<ILogger<ExceptionHandlingMiddleware>>();

            var handler = handlerFactory.TryCreate(ex);

            if (handler == null)
            {
                logger.LogError(ex, "Unhandled exception occurred!");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(ex.ToHttpResponseModel(), Json.DefaultSerializerOptions));
            }
            else
            {
                await handler.HandleAsync(context, ex);
            }
        }
    }
}
