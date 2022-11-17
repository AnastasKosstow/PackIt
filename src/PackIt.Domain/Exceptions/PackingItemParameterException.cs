using PackIt.Domain.Abstractions;

namespace PackIt.Domain.Exceptions;

public class PackingItemParameterException : DomainException
{
    internal PackingItemParameterException()
    {
        this.ErrorMessage = "One of PackingItem parameters is null or empty.";
    }

    internal PackingItemParameterException(string message)
    {
        this.ErrorMessage = message;
    }
}
