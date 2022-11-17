using PackIt.Domain.Abstractions;

namespace PackIt.Domain.Exceptions;

internal class PackingItemAlreadyExistsException : DomainException
{
    internal PackingItemAlreadyExistsException()
    {
        this.ErrorMessage = "Packing item with the same name already exists.";
    }
}
