using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Shamyr.AspNetCore.HttpErrors;

namespace Shamyr.AspNetCore.Handlers.Exceptions;

public abstract class CodeExceptionHadlerBase<TException>: ExceptionHandlerBase<TException>
    where TException : Exception
{
    protected abstract int StatusCode { get; }

    protected override async Task DoHandleAsync(HttpContext context, TException ex)
    {
        context.Response.StatusCode = StatusCode;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(
            JsonSerializer.Serialize(CreateModel(ex), Json.DefaultSerializerOptions),
            context.RequestAborted);
    }

    protected virtual HttpErrorResponseModel CreateModel(TException ex)
    {
        return ex.ToHttpResponseModel();
    }
}
