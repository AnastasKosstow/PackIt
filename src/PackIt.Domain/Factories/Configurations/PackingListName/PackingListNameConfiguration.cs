namespace PackIt.Domain.Factories.Configurations.PackingListName;

internal sealed class PackingListNameConfiguration : IPackingListNameConfiguration
{
    public string Value { get; set; }

    public IPackingListNameConfiguration Name(string value)
    {
        Value = value ?? default;
        return this;
    }
}
