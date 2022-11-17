using PackIt.Domain.Abstractions;

namespace PackIt.Domain.Exceptions;

public class EmptyPackingListNameException : DomainException
{
    internal EmptyPackingListNameException()
    {
        this.ErrorMessage = "Packing list name cannot be empty.";
    }
}
