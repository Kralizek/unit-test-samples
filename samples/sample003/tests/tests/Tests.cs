using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Web;

namespace tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public async Task ShouldReturnExpectedForecast()
        {
            var testWeatherForecast = new WeatherForecast
            {
                Date = DateTime.Today,
                Summary = "All good!",
                TemperatureC = 25
            };

            var factory = new WebApplicationFactory<Web.Startup>().WithWebHostBuilder(builder => 
            {
                var fake = new FakeWeatherForecastService(testWeatherForecast);

                builder.ConfigureServices(services => services.AddSingleton<IWeatherForecastService>(fake));
            });

            var client = factory.CreateClient();

            var result = await client.GetFromJsonAsync<WeatherForecast[]>("/WeatherForecast/");

            Assert.That(result[0], Is.EqualTo(testWeatherForecast));
        }

        private class FakeWeatherForecastService : IWeatherForecastService
        {
            private readonly WeatherForecast _forecast;

            public FakeWeatherForecastService(WeatherForecast forecast)
            {
                _forecast = forecast;
            }

            public IEnumerable<WeatherForecast> Get() => new [] { _forecast };
        }
    }
}