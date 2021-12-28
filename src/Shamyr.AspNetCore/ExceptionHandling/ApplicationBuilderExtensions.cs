using Microsoft.AspNetCore.Builder;

namespace Shamyr.AspNetCore.ExceptionHandling;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();

        return app;
    }
}
