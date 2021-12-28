using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Shamyr.AspNetCore.Handlers.Exceptions;

public abstract class ExceptionHandlerBase<TException>: IExceptionHandler
    where TException : Exception
{
    public bool CanHandle(Exception exception)
    {
        return exception is TException;
    }

    public async Task HandleAsync(HttpContext httpContext, Exception ex)
    {
        await DoHandleAsync(httpContext, (TException)ex);
    }

    protected abstract Task DoHandleAsync(HttpContext httpContext, TException ex);
}
