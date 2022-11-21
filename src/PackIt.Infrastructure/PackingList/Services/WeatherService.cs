using PackIt.Application.PackingList.Shared.DTOs.External;
using PackIt.Application.PackingList.Shared.Services;

namespace PackIt.Infrastructure.PackingList.Services;

public sealed class WeatherService : IWeatherService
{
    public Task<WeatherDto> GetWeatherAsync(string country, string city)
    {
        return Task.FromResult(new WeatherDto(0));
    }
}
