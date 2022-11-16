namespace PackIt.Domain.ValueObjects;

internal record PackingListName
{
    public string Value { get; private set; }

	public PackingListName(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
		{

		}

		Value = value;
	}
}
