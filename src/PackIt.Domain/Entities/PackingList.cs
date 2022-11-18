using PackIt.Domain.Abstractions;
using PackIt.Domain.Exceptions;
using PackIt.Domain.ValueObjects;

namespace PackIt.Domain.Entities;

public sealed class PackingList : IAggregateRoot
{
    public Guid Id { get; private set; }

    private PackingListName name;
    private Localization localization;
    private Temperature temperature;

    private readonly LinkedList<PackingItem> items;

    internal PackingList(Guid id, PackingListName name, Localization localization, Temperature temperature, LinkedList<PackingItem> items)
        : this(id, name, localization, temperature)
    {
        this.items = items;
    }

    internal PackingList(Guid id, PackingListName name, Localization localization, Temperature temperature)
    {
        Id = id;
        this.name = name;
        this.localization = localization;
        this.temperature = temperature;
    }

    public void AddItem(PackingItem item)
    {
        var alreadyExists = items.Any(pi => pi.Name == item.Name);
        if (alreadyExists)
        {
            throw new PackingItemAlreadyExistsException();
        }

        items.AddLast(item);
    }

    public void PackItem(string name)
    {
        var item = items.FirstOrDefault(pi => pi.Name == name);
        if (item is null)
        {
            throw new PackingItemNotFoundException($"Packing item with name - '{name}' not found.");
        }

        item.PackItem();
    }
}
