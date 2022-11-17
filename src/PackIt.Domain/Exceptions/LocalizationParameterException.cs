using PackIt.Domain.Abstractions;

namespace PackIt.Domain.Exceptions;

public class LocalizationParameterException : DomainException
{
    internal LocalizationParameterException()
    {
        this.ErrorMessage = "One of Localization parameters is null or empty.";
    }

    internal LocalizationParameterException(string message)
    {
        this.ErrorMessage = message;
    }
}
