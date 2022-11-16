using PackIt.Domain.Entities;

namespace PackIt.Domain.Factories;

internal sealed class PackingListFactory : IPackingListFactory
{
    public PackingList Build()
        =>
        new();
}
