namespace PackIt.Domain.Entities;

public sealed class PackingList
{
    public Guid Id { get; private set; }

    private string name;
    private string localization;

    internal PackingList()
    {

    }
}
