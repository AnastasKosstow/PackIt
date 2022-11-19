using PackIt.Application.PackingList.DTOs.External;

namespace PackIt.Application.PackingList.Services;

public interface IWeatherService
{
    Task<WeatherDto> GetWeatherAsync(string country, string city);
}
