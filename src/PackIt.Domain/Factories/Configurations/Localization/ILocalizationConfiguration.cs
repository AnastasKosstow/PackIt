namespace PackIt.Domain.Factories.Configurations.Localization;

public interface ILocalizationConfiguration
{
    ILocalizationConfiguration Country(string country);
    ILocalizationConfiguration City(string city);
}
