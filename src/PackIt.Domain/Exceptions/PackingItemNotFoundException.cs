namespace PackIt.Domain.Exceptions;

public class PackingItemNotFoundException : Exception
{
    private const string DEFAULT_MESSAGE = "Packing item not found.";

    internal PackingItemNotFoundException()
        : base(string.Format(DEFAULT_MESSAGE))
    {
    }

    internal PackingItemNotFoundException(string message)
        : base(string.Format(message))
    {
    }
}
