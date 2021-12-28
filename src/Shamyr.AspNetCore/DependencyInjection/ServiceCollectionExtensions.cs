using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Shamyr.AspNetCore.ExceptionHandling;
using Shamyr.AspNetCore.Factories;
using Shamyr.AspNetCore.Handlers.Exceptions;

namespace Shamyr.AspNetCore.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddExceptionHandling(this IServiceCollection services, params Assembly[] externalAssemblies)
    {
        var assemblies = new List<Assembly>(externalAssemblies) { typeof(IExceptionHandler).Assembly };
        services.Scan(s =>
        {
            s.FromAssemblies(assemblies)
             .AddClasses(c => c.AssignableTo(typeof(IExceptionHandler)))
             .AsImplementedInterfaces()
             .WithTransientLifetime();
        });

        services.AddTransient<ExceptionHandlingMiddleware>();
        services.AddTransient<IExceptionHandlerFactory, ExceptionHandlerFactory>();
    }
}
