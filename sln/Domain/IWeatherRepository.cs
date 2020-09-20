using System.Threading.Tasks;

namespace Domain
{
    public interface IWeatherRepository
    {
        Task SaveAsync(WeatherReading reading);
    }
}
