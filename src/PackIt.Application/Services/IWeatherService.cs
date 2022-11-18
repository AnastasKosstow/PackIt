using PackIt.Application.DTOs.External;

namespace PackIt.Application.Services;

public interface IWeatherService
{
    Task<WeatherDto> GetWeatherAsync(string country, string city);
}
