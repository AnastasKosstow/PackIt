using PackIt.Domain.ValueObjects;

namespace PackIt.Domain.Entities;

public sealed class PackingList
{
    public Guid Id { get; private set; }

    private PackingListName name;
    private Localization localization;

    internal PackingList(Guid id, PackingListName name, Localization localization)
    {
        Id = id;
        this.name = name;
        this.localization = localization;
    }
}
