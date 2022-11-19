using PackIt.Application.Abstractions;
using PackIt.Application.PackingList.Exceptions;
using PackIt.Application.PackingList.Services;
using PackIt.Domain.Factories;
using PackIt.Domain.Repositories;

namespace PackIt.Application.PackingList.Commands;

public record CreatePackingList(Guid Id, string Name, string Country, string City)
    : ICommand;


public class CreatePackingListHandler : ICommandHandler<CreatePackingList>
{
    private readonly IPackingListFactory factory;
    private readonly IPackingListRepository repository;
    private readonly IPackingListReadService readService;
    private readonly IWeatherService weatherService;

    public CreatePackingListHandler(
        IPackingListFactory factory,
        IPackingListRepository repository,
        IPackingListReadService readService,
        IWeatherService weatherService)
    {
        this.factory = factory;
        this.repository = repository;
        this.readService = readService;
        this.weatherService = weatherService;
    }

    public async Task HandleAsync(CreatePackingList command, CancellationToken cancellationToken)
    {
        var (id, name, country, city) = command;

        if (await readService.ExistsByNameAsync(command.Name))
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

        await repository.AddAsync(packingList);
    }
}
