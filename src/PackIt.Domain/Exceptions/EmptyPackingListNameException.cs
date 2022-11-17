namespace PackIt.Domain.Exceptions;

public class EmptyPackingListNameException : Exception
{
    private const string DEFAULT_MESSAGE = "Packing list name cannot be empty.";

    internal EmptyPackingListNameException()
        : base(string.Format(DEFAULT_MESSAGE))
    {
    }

    internal EmptyPackingListNameException(string message)
        : base(string.Format(message))
    {
    }
}
