using PackIt.Domain.Abstractions.Exceptions;

namespace PackIt.Domain.Exceptions;

public class LocalizationParameterException : BaseDomainException
{
    internal LocalizationParameterException()
    {
        this.ErrorMessage = "One of localization parameters is null or empty.";
    }

    internal LocalizationParameterException(string message)
    {
        this.ErrorMessage = message;
    }
}
