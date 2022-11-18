using Microsoft.Extensions.DependencyInjection;
using PackIt.Application.Abstractions;
using PackIt.Application.Dispatcher;
using System.Reflection;

namespace PackIt.Application;

public static class ApplicationConfiguration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<ICommandDispacher, InMemoryCommandDispatcher>();

        var handlers = new List<Type>();
        handlers.AddRange(GetClassesImplementingInterface());

        handlers.ForEach(handler =>
        {
            services.AddScoped(handler);
        });

        return services;
    }

    private static IEnumerable<Type> GetClassesImplementingInterface()
    {
        return Assembly.GetExecutingAssembly()
            .ExportedTypes
            .Where(type =>
            {
                var implementRequestType = type
                    .GetInterfaces()
                    .Any(@interface => @interface.IsGenericType &&
                                       @interface.GetGenericTypeDefinition() == typeof(ICommandHandler<>));

                return implementRequestType;
            });
    }
}
