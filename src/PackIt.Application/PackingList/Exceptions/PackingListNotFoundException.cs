namespace PackIt.Application.PackingList.Exceptions;

internal class PackingListNotFoundException : Exception
{
    private const string DEFAULT_MESSAGE = "Packing list not found.";

    internal PackingListNotFoundException()
        : base(string.Format(DEFAULT_MESSAGE))
    {
    }

    internal PackingListNotFoundException(string message)
        : base(string.Format(message))
    {
    }
}
