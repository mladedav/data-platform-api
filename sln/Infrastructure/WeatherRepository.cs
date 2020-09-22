using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mladedav.DataPlatform.Domain;
using MongoDB.Driver;

namespace Mladedav.DataPlatform.Infrastructure
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly MongoClient _client;
        private readonly IMongoCollection<WeatherReadingModel> _readings;

        public WeatherRepository(MongoSettings settings)
        {
            _client = new MongoClient(settings.ConnectionString);
            var database = _client.GetDatabase(settings.DatabaseName);
            _readings = database.GetCollection<WeatherReadingModel>(settings.CollectionName);
        }

        public async Task<List<WeatherReading>> GetAsync(int start, int count)
        {
            var entities = await _readings
                .Find(FilterDefinition<WeatherReadingModel>.Empty)
                .SortBy(reading => reading.Timestamp)
                .Skip(start)
                .Limit(count)
                .ToListAsync();
            return entities.Select(entity => (WeatherReading)entity).ToList();
        }

        public Task SaveAsync(WeatherReading reading) =>
            _readings.InsertOneAsync(reading);
    }
}
