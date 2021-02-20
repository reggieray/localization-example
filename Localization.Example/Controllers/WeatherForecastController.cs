using Localization.Example.Resources;
using Localization.Example.Weather;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Localization.Example.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherForecastController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Gets the weather forecast.
        /// </summary>
        /// <param name="lang">The language. Support languages en-US, es-ES, zh-CN</param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<WeatherForecast> Get([FromQuery] string lang = WeatherLocale.DefaultLocale)
        {
            var cultureInfo = WeatherLocale.GetLocale(lang);
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = WeatherSummaries.ResourceManager.GetString(Summaries[rng.Next(Summaries.Length)], cultureInfo)
            })
            .ToArray();
        }
    }
}
