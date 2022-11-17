namespace PackIt.Domain.Exceptions;

public class LocalizationParameterException : Exception
{
    private const string DEFAULT_MESSAGE = "One of Localization parameters is null or empty.";

    internal LocalizationParameterException()
        : base(string.Format(DEFAULT_MESSAGE))
    {
    }

    internal LocalizationParameterException(string message)
        : base(string.Format(message))
    {
    }
}
