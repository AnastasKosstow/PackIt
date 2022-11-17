using PackIt.Domain.Abstractions;
using PackIt.Domain.Exceptions;
using PackIt.Domain.ValueObjects;

namespace PackIt.Domain.Entities;

public sealed class PackingList : IAggregateRoot
{
    public Guid Id { get; private set; }

    private PackingListName name;
    private Localization localization;

    private readonly LinkedList<PackingItem> items;

    internal PackingList(Guid id, PackingListName name, Localization localization, LinkedList<PackingItem> items)
    {
        Id = id;
        this.name = name;
        this.localization = localization;
    }

    internal void AddItem(PackingItem item)
    {
        var alreadyExists = items.Any(x => x.Name == item.Name);
        if (alreadyExists)
        {
            throw new PackingItemAlreadyExistsException();
        }

        items.AddLast(item);
    }
}
