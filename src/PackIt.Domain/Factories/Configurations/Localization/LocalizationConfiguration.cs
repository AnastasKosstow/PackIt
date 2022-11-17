namespace PackIt.Domain.Factories.Configurations.Localization;

internal sealed class LocalizationConfiguration : ILocalizationConfiguration
{
    public string CountryValue { get; set; }
    public string CityValue { get; set; }

    public ILocalizationConfiguration Country(string country)
    {
        CountryValue = country ?? default;
        return this;
    }

    public ILocalizationConfiguration City(string city)
    {
        CityValue = city ?? default;
        return this;
    }
}
