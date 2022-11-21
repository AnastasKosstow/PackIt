namespace PackIt.Application.PackingList.Shared.Exceptions;

internal class MissingLocalizationWeatherException : Exception
{
    private const string DEFAULT_MESSAGE = "Couldn`t fetch data for localization.";

    internal MissingLocalizationWeatherException()
        : base(string.Format(DEFAULT_MESSAGE))
    {
    }

    internal MissingLocalizationWeatherException(string message)
        : base(string.Format(message))
    {
    }
}
