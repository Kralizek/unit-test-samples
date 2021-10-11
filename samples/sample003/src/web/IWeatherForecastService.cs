using System;
using System.Collections.Generic;

namespace Web
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Get();
    }

    public record WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
