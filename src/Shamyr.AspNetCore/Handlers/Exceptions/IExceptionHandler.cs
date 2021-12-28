using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Shamyr.AspNetCore.Handlers.Exceptions;

public interface IExceptionHandler
{
    bool CanHandle(Exception exception);
    Task HandleAsync(HttpContext context, Exception ex);
}
