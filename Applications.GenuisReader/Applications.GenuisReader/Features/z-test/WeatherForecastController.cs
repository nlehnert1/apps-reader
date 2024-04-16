using GeniusReader.Domain.EFModel;
using GeniusReader.WebApp.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Applications.GenuisReader.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private ReaderContext _testContext;
        public WeatherForecastController(ReaderContext testContext, ILogger<WeatherForecastController> logger)
        {
            this._testContext = testContext;
            this._logger = logger;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("Test")]
        public IEnumerable<TestEntityDto> GetTestData()
        {
            var testEntities = _testContext.TestEntity.Select(x => new TestEntityDto {
                Id = x.TestId,
                Contents = x.Contents,
            });
            return testEntities.ToList(); ;
        }
    }
}
