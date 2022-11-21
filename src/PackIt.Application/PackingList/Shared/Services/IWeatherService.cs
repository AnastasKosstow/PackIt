using PackIt.Application.PackingList.Shared.DTOs.External;

namespace PackIt.Application.PackingList.Shared.Services;

public interface IWeatherService
{
    Task<WeatherDto> GetWeatherAsync(string country, string city);
}
