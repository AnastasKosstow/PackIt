namespace PackIt.Domain.Exceptions;

public class PackingItemParameterException : Exception
{
    private const string DEFAULT_MESSAGE = "One of PackingItem parameters is null or empty.";

    internal PackingItemParameterException()
        : base(string.Format(DEFAULT_MESSAGE))
    {
    }

    internal PackingItemParameterException(string message)
        : base(string.Format(message))
    {
    }
}
