using PackIt.Domain.Abstractions;
using PackIt.Domain.Entities;
using PackIt.Domain.Factories.Configurations.Localization;

namespace PackIt.Domain.Factories;

public interface IPackingListFactory : IFactory<PackingList>
{
    IPackingListFactory WithId(Guid Id);
    IPackingListFactory WithName(string name);
    IPackingListFactory WithLocalization(Action<ILocalizationConfiguration> localizationAction);
}
