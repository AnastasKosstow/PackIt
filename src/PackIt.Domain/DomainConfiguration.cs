using Microsoft.Extensions.DependencyInjection;
using PackIt.Domain.Factories;

namespace PackIt.Domain;

public static class DomainConfiguration
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddSingleton<IPackingListFactory, PackingListFactory>();
        return services;
    }
}
