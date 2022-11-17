namespace PackIt.Domain.Exceptions;

public class InvalidTemperatureException : Exception
{
    private const string DEFAULT_MESSAGE = "Invalid temperature value.";

    internal InvalidTemperatureException()
        : base(string.Format(DEFAULT_MESSAGE))
    {
    }

    internal InvalidTemperatureException(string message)
        : base(string.Format(message))
    {
    }
}
