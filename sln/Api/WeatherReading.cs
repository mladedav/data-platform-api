using System;

namespace Api
{
    public class WeatherReading
    {
        public DateTime Timestamp { get; set; }

        public int Temperature { get; set; }

        public int Humidity { get; set; }

        public override string ToString() => $"{Timestamp.ToString("O")}: Temperature - {Temperature} °C, Humidity - {Humidity} %";
    }
}
