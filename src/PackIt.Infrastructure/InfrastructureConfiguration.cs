using PackIt.Application.PackingList;
using PackIt.Application.PackingList.Shared.Services;
using PackIt.Infrastructure.PackingList.EF;
using PackIt.Infrastructure.PackingList.Repositories;
using PackIt.Infrastructure.PackingList.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackIt.Shared.Extensions;
using PackIt.Infrastructure.PackingList.EF.Options;
using Microsoft.EntityFrameworkCore;
using PackIt.Domain.Repositories;

namespace PackIt.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);

        services
            .AddScoped<IPackingListQueryRepository, PackingListQueryRepository>()
            .AddScoped<IPackingListDomainRepository, PackingListDomainRepository>()
            .AddScoped<IWeatherService, WeatherService>();

        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var postgresOptions = configuration.GetOptions<Postgres>(nameof(Postgres));

        services.AddDbContext<PackingListDbContext>(ctx =>
        {
            ctx.UseNpgsql(postgresOptions.ConnectionString);
        });

        return services;
    }
}
