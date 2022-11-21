using PackIt.Domain.Abstractions;
using PackIt.Domain.Exceptions;
using PackIt.Domain.ValueObjects;

namespace PackIt.Domain.Entities;

public sealed class PackingList : IAggregateRoot
{
    public Guid Id { get; private set; }
    public PackingListName Name { get; private set; }
    public Localization Localization { get; private set; }
    public Temperature Temperature { get; private set; }
    public LinkedList<PackingItem> Items { get; private set; }

    private PackingList()
    {
    }

    internal PackingList(Guid id, PackingListName name, Localization localization, Temperature temperature, LinkedList<PackingItem> items)
        : this(id, name, localization, temperature)
    {
        Items = items;
    }

    internal PackingList(Guid id, PackingListName name, Localization localization, Temperature temperature)
    {
        Id = id;
        Name = name;
        Localization = localization;
        Temperature = temperature;
    }

    public void AddItem(PackingItem item)
    {
        var alreadyExists = Items.Any(pi => pi.Name == item.Name);
        if (alreadyExists)
        {
            throw new PackingItemAlreadyExistsException();
        }

        Items.AddLast(item);
    }

    public void AddItems(IEnumerable<PackingItem> items)
    {
        foreach (var item in items)
        {
            AddItem(item);
        }
    }

    public void PackItem(string name)
    {
        var item = GetItem(name);
        item.PackItem();
    }

    public void RemoveItem(string name)
    {
        var item = GetItem(name);
        Items.Remove(item);
    }

    private PackingItem GetItem(string name)
    {
        var item = Items.SingleOrDefault(pi => pi.Name == name);
        if (item is null)
        {
            throw new PackingItemNotFoundException($"Packing item with name - '{name}' not found.");
        }

        return item;
    }
}
