using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherService _service;
        private readonly ILogger<WeatherController> _logger;

        public WeatherController(WeatherService service, ILogger<WeatherController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]WeatherReading reading)
        {
            _logger.LogDebug(reading.ToString());
            await _service.SaveAsync(reading);
            return Ok();
        }
    }
}
