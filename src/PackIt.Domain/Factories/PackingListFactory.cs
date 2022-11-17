using PackIt.Domain.Entities;
using PackIt.Domain.ValueObjects;
using PackIt.Domain.Factories.Configurations.Localization;

namespace PackIt.Domain.Factories;

internal sealed class PackingListFactory : IPackingListFactory
{
    private Guid id;
    private PackingListName listName;
    private Localization localization;
    private Temperature temperature;

    public IPackingListFactory WithId(Guid id)
    {
        this.id = id;
        return this;
    }

    public IPackingListFactory WithName(string name)
    {
        this.listName = new PackingListName(name);
        return this;
    }

    public IPackingListFactory WithTemperature(double temperature)
    {
        this.temperature = new Temperature(temperature);
        return this;
    }

    public IPackingListFactory WithLocalization(Action<ILocalizationConfiguration> localizationAction)
    {
        var configuration = new LocalizationConfiguration();
        localizationAction?.Invoke(configuration);

        this.localization = new Localization(configuration.CountryValue, configuration.CityValue);
        return this;
    }

    public PackingList Build()
        =>
        new(id, listName, localization, temperature);
}
