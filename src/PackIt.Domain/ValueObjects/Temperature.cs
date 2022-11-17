using PackIt.Domain.Exceptions;

namespace PackIt.Domain.ValueObjects;

public record Temperature
{
    public double Value { get; private set; }

    public Temperature(double value)
    {
        if (value is < -50 or > 50)
        {
            throw new InvalidTemperatureException($"Invalid temperature value - {value}.");
        }

        Value = value;
    }
}