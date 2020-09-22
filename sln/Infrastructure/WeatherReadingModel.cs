using System;
using Mladedav.DataPlatform.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mladedav.DataPlatform.Infrastructure
{
    public class WeatherReadingModel
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id { get; set; }
        public DateTime Timestamp { get; set; }

        public int Temperature { get; set; }

        public int Humidity { get; set; }

        public static implicit operator WeatherReadingModel(WeatherReading model) =>
            new WeatherReadingModel
            {
                Timestamp = model.Timestamp,
                Temperature = model.Temperature,
                Humidity = model.Humidity,
            };

        public static implicit operator WeatherReading(WeatherReadingModel model) =>
            new WeatherReading
            {
                Timestamp = model.Timestamp,
                Temperature = model.Temperature,
                Humidity = model.Humidity,
            };
    }
}
