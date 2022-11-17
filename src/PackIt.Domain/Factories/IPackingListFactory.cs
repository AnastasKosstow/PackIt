using PackIt.Domain.Abstractions;
using PackIt.Domain.Entities;
using PackIt.Domain.Factories.Configurations.Localization;
using PackIt.Domain.Factories.Configurations.PackingListName;

namespace PackIt.Domain.Factories;

public interface IPackingListFactory : IFactory<PackingList>
{
    IPackingListFactory WithId(Guid Id);
    IPackingListFactory WithName(Action<IPackingListNameConfiguration> packingListNameAction);
    IPackingListFactory WithLocalization(Action<ILocalizationConfiguration> localizationAction);
}
