using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mladedav.DataPlatform.Domain;

namespace Mladedav.DataPlatform.Api.Controllers
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

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery]int start, [FromQuery]int count)
        {
            if (start < 0 || count < 0)
            {
                return BadRequest();
            }
            var result = await _service.GetAsync(start, count);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]WeatherReading reading)
        {
            _logger.LogDebug(reading.ToString());
            await _service.SaveAsync(reading);
            return Ok();
        }
    }
}
