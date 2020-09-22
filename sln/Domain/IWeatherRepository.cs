using System.Threading.Tasks;

namespace Mladedav.DataPlatform.Domain
{
    public interface IWeatherRepository
    {
        Task SaveAsync(WeatherReading reading);
    }
}
