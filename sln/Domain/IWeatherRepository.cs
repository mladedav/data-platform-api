using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mladedav.DataPlatform.Domain
{
    public interface IWeatherRepository
    {
        Task<List<WeatherReading>> GetAsync(int start, int count);
        Task SaveAsync(WeatherReading reading);
    }
}
