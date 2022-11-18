namespace PackIt.Application.Exceptions;

internal class PackingListAlreadyExistsException : Exception
{
    private const string DEFAULT_MESSAGE = "Packing list with this name already exists.";

    internal PackingListAlreadyExistsException()
        : base(string.Format(DEFAULT_MESSAGE))
    {
    }

    internal PackingListAlreadyExistsException(string message)
        : base(string.Format(message))
    {
    }
}
