using System.Threading.Tasks;
using Mladedav.DataPlatform.Domain;
using MongoDB.Driver;

namespace Mladedav.DataPlatform.Infrastructure
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly MongoClient _client;
        private readonly IMongoCollection<WeatherReading> _readings;

        public WeatherRepository(MongoSettings settings)
        {
            _client = new MongoClient(settings.ConnectionString);
            var database = _client.GetDatabase(settings.DatabaseName);
            _readings = database.GetCollection<WeatherReading>(settings.CollectionName);
        }

        public Task SaveAsync(WeatherReading reading) =>
            _readings.InsertOneAsync(reading);
    }
}
