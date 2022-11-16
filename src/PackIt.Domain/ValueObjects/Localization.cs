using PackIt.Domain.Exceptions;

namespace PackIt.Domain.ValueObjects;

internal record Localization
{
    public string City { get; private set; }
    public string Country { get; private set; }

    public Localization(string city, string country)
    {
        if (string.IsNullOrWhiteSpace(city))
        {
            string message = $"Localization parameter \"{nameof(city)}\" cannot be empty.";
            throw new LocalizationParameterException(message);
        }
        if (string.IsNullOrWhiteSpace(country))
        {
            string message = $"Localization parameter \"{nameof(country)}\" cannot be empty.";
            throw new LocalizationParameterException(message);
        }

        City = city;
        Country = country;
    }

    public override string ToString()
    {
        return $"Country: {this.Country}, City: {this.City}";
    }
}
