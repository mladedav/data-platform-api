using System.Threading.Tasks;

namespace Domain
{
    public class WeatherService
    {
        private IWeatherRepository _repository;

        public WeatherService(IWeatherRepository repository)
        {
            _repository = repository;
        }

        public Task SaveAsync(WeatherReading reading) => _repository.SaveAsync(reading);
    }
}