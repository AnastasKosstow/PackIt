using PackIt.Domain.Abstractions.Exceptions;

namespace PackIt.Domain.Exceptions;

public class LocalizationParameterException : BaseDomainException
{
    public LocalizationParameterException()
    {
        this.ErrorMessage = "One of localization parameters is null or empty.";
    }

    public LocalizationParameterException(string message)
    {
        this.ErrorMessage = message;
    }
}
