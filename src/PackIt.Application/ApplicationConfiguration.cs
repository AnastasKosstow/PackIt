using Microsoft.Extensions.DependencyInjection;
using PackIt.Application.Abstractions;
using PackIt.Application.Dispatcher;
using System.Reflection;

namespace PackIt.Application;

public static class ApplicationConfiguration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<ICommandDispatcher, InMemoryCommandDispatcher>();

        var handlers = 
            GetCommandHandlersClasses()
            .ToList();


        handlers.ForEach(handler =>
        {
            // ICommandHandler`1 - search for ICommandHandler interface with one generic argument
            services.AddScoped(handler.GetInterface("ICommandHandler`1"), handler);
        });

        return services;
    }

    private static IEnumerable<Type> GetCommandHandlersClasses()
    {
        return Assembly.GetExecutingAssembly()
            .ExportedTypes
            .Where(type =>
            {
                var implementType = type
                    .GetInterfaces()
                    .Any(@interface => @interface.IsGenericType &&
                                       @interface.GetGenericTypeDefinition() == typeof(ICommandHandler<>));

                return implementType;
            });
    }
}
