using PackIt.Domain.Abstractions.Exceptions;

namespace PackIt.Domain.Exceptions;

public class EmptyPackingListNameException : BaseDomainException
{
    public EmptyPackingListNameException()
    {
        this.ErrorMessage = "Packing list name cannot be empty.";
    }
}
