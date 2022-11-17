using PackIt.Domain.Entities;
using PackIt.Domain.Factories.Configurations.Localization;
using PackIt.Domain.Factories.Configurations.PackingListName;
using PackIt.Domain.ValueObjects;

namespace PackIt.Domain.Factories;

internal sealed class PackingListFactory : IPackingListFactory
{
    private Guid id;
    private PackingListName listName;
    private Localization localization;

    public IPackingListFactory WithId(Guid id)
    {
        this.id = id;
        return this;
    }

    public IPackingListFactory WithName(Action<IPackingListNameConfiguration> packingListNameAction)
    {
        var configuration = new PackingListNameConfiguration();
        packingListNameAction?.Invoke(configuration);
        return this;
    }

    public IPackingListFactory WithLocalization(Action<ILocalizationConfiguration> localizationAction)
    {
        var configuration = new LocalizationConfiguration();
        localizationAction?.Invoke(configuration);
        return this;
    }

    public PackingList Build()
        =>
        new(id, listName, localization);
}
