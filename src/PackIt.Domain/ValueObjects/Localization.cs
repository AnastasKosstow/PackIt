using PackIt.Domain.Exceptions;

namespace PackIt.Domain.ValueObjects;

public record Localization
{
    public string City { get; private set; }
    public string Country { get; private set; }

    public Localization(string city, string country)
    {
        if (string.IsNullOrWhiteSpace(city))
        {
            throw new LocalizationParameterException($"Localization parameter \"{nameof(city)}\" cannot be empty.");
        }
        if (string.IsNullOrWhiteSpace(country))
        {
            throw new LocalizationParameterException($"Localization parameter \"{nameof(country)}\" cannot be empty.");
        }

        City = city;
        Country = country;
    }

    public static Localization Create(string value)
    {
        var splitLocalization = value.Split(',');
        return new Localization(splitLocalization.First(), splitLocalization.Last());
    }

    public override string ToString()
    {
        return $"Country: {this.Country}, City: {this.City}";
    }
}
