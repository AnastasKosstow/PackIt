namespace PackIt.Domain.Exceptions;

internal class PackingItemAlreadyExistsException : Exception
{
    private const string DEFAULT_MESSAGE = "Packing item with the same name already exists.";

    internal PackingItemAlreadyExistsException()
        : base(string.Format(DEFAULT_MESSAGE))
    {
    }

    internal PackingItemAlreadyExistsException(string message)
        : base(string.Format(message))
    {
    }
}
