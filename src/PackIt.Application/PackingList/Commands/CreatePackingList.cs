using PackIt.Application.Abstractions;
using PackIt.Application.PackingList.Shared.Exceptions;
using PackIt.Application.PackingList.Shared.Services;
using PackIt.Domain.Factories;
using PackIt.Domain.Repositories;

namespace PackIt.Application.PackingList.Commands;

public record CreatePackingList(Guid Id, string Name, string Country, string City)
    : ICommand;


public class CreatePackingListHandler : ICommandHandler<CreatePackingList>
{
    private readonly IWeatherService weatherService;
    private readonly IPackingListFactory factory;
    private readonly IPackingListQueryRepository queryRepository;
    private readonly IPackingListDomainRepository domainRepository;

    public CreatePackingListHandler(
        IWeatherService weatherService,
        IPackingListFactory factory,
        IPackingListQueryRepository queryRepository,
        IPackingListDomainRepository domainRepository)
    {
        this.factory = factory;
        this.weatherService = weatherService;
        this.queryRepository = queryRepository;
        this.domainRepository = domainRepository;
    }

    public async Task HandleAsync(CreatePackingList command, CancellationToken cancellationToken)
    {
        var (id, name, country, city) = command;

        if (await queryRepository.ExistsByNameAsync(command.Name))
        {
            throw new PackingListAlreadyExistsException($"Packing list with name - '{name}' already exists.");
        }

        var weather = await weatherService.GetWeatherAsync(country, city);
        if (weather is null)
        {
            throw new MissingLocalizationWeatherException($"Couldn`t fetch data for localization -" +
                $"\n'Country: {country}'" +
                $"\n'City: {city}'");
        }

        var packingList = factory
            .WithId(id)
            .WithName(name)
            .WithLocalization(localization =>
            {
                localization.Country(country);
                localization.City(city);
            })
            .WithTemperature(weather.Temperature)
            .Build();

        await domainRepository.AddAsync(packingList);
    }
}
