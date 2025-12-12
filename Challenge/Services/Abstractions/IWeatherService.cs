using Challenge.Data;

namespace Challenge.Services.Abstractions
{
    public interface IWeatherService
    {
        public Task<Root> GetWeather(string cityName);
    }
}
