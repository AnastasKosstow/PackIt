﻿using PackIt.Domain.Exceptions;

namespace PackIt.Domain.ValueObjects;

internal record PackingItem
{
    public string Name { get; private set; }
    public ushort Quantity { get; private set; }
    public bool IsPacked { get; private set; }

    internal PackingItem(string name, ushort quantity)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new PackingItemParameterException($"PackingItem parameter \"{nameof(name)}\" cannot be empty.");
        }
        if (quantity == 0)
        {
            throw new PackingItemParameterException($"PackingItem parameter \"{nameof(quantity)}\" cannot be 0.");
        }

        this.Name = name;
        this.Quantity = quantity;
        this.IsPacked = false;
    }
}